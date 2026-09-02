### Opgavebesvarelse

## Polymorfi
Polymorfi ses konkret i metoden `PrintMonthlySalaryOverview()` i `Output`-klassen:

```
foreach (var employee in Init.Employees)
{
    totalSalary += employee.CalculateSalary();
    Console.WriteLine(employee.Description());
}
```

`Init.Employees` er en liste med objekter af typen **Employee**, hvor  variablen `employee` bliver en reference til base-klassen **Employee**.

Listen indeholder både objekter af subtyperne **HourlyEmployee** og **SalariedEmployee**, der nedarver fra typen **Employee**:

```
Employees.Add(new HourlyEmployee(...));
Employees.Add(new SalariedEmployee(...));
```

Når man så kalder:

`employee.CalculateSalary();`

afhænger implementeringen af `CalculateSalary()`-metoden af, hvilket objekt `employee` refererer til.
Hvis det er en **HourlyEmployee**, bliver den implementering kaldt, som hører til **HourlyEmployee**, og hvis det er en **SalariedEmployee**, bliver den implementering kaldt, som hører til **SalariedEmployee**.

For **HourlyEmployee**:
`public override decimal CalculateSalary() => HourlyRate * HoursWorked;`

For **SalariedEmployee**:
`public override decimal CalculateSalary() => BaseSalary + Bonus;`

Det betyder altså, at jeg kan kalde den samme metode:

`employee.CalculateSalary();`

men få forskellig adfærd alt efter om den employee, der bliver arbejdet på, er en **HourlyEmployee** eller en **SalariedEmployee**.

Det er **_polymorfi_** fordi begge typer kan behandles som en **Employee**, men stadig bruger deres egen implementation af `CalculateSalary()`,
og forskellige typer af objekter kan have forskellig adfærd, selvom employee refereres gennem den generiske basisklasse **Employee**.

## Hvad sker der uden virtual og override?
### 1. virtual og override
Som koden er nu er `CalculateSalary()` i **Employee** markeret med `virtual`, og de afledte klasser **HourlyEmployee** og **SalariedEmployee** med `override` på deres implementeringer af metoden.

Når man skriver:
```
foreach (var employee in Init.Employees)
{
    totalSalary += employee.CalculateSalary();
}
```

er `employee` en reference til **Employee**, men objektet kan stadig være en **HourlyEmployee** eller en **SalariedEmployee**. 
Derfor bliver den rigtige implementering af `CalculateSalary()` kaldt, og den returnerer den korrekte løn for den specifikke medarbejder, på baggrund af deres specifikke type.

**HourlyEmployee** returnerer HourlyRate * HoursWorked
**SalariedEmployee** returnerer BaseSalary + Bonus

Derfor bliver lønnen beregnet korrekt for hver medarbejder, og den samlede løn bliver også korrekt.

### 2. new i afledte klasser
Hvis override erstattes med new:

`public new decimal CalculateSalary() => HourlyRate * HoursWorked;`

og

`public new decimal CalculateSalary() => BaseSalary + Bonus;`

er metoderne ikke længere polymorfe, men almindelige metoder, som i stedet skjuler metoden i base-klassen.

Hvis man bruger den samme foreach-loop:

```
foreach (var employee in Init.Employees)
{
    totalSalary += employee.CalculateSalary();
}
```

er `employee` stadig en reference til **Employee**, og derfor bliver `CalculateSalary()` fra **Employee** kaldt, som returnerer 0.

Den samlede løn vil derfor også blive 0, og selvom objekterne faktisk er **HourlyEmployee** eller **SalariedEmployee**, bliver deres implementeringer af `CalculateSalary()` ikke kaldt gennem en **Employee**-reference.

### 3. Ingen virtual og override, samme metode-kald
Hvis man fjerner både virtual og override, bliver `CalculateSalary()` i **Employee** en almindelig metode, og de afledte klasser har deres egne metoder med samme navn, men de er ikke polymorfe.

i Employee:
`public decimal CalculateSalary() => 0;`

og i afledte klasser:

`public decimal CalculateSalary() => HourlyRate * HoursWorked;`

og

`public decimal CalculateSalary() => BaseSalary + Bonus;`

I de afledte klasser bliver metoderne almindelige metoder med samme navn.

Hvis man beholder foreach-loopet som det er:

```
foreach (var employee in Init.Employees)
{
    totalSalary += employee.CalculateSalary();
}
```

er `employee` stadig en reference til **Employee**, og derfor bliver `CalculateSalary()` fra **Employee** kaldt, som returnerer 0.
Outputtet bliver derfor det samme som i ekselmpel 2, hvor den samlede løn bliver udregnet til 0.

### 4. Ingen virtual og override, men forskellige metode-kald
Hvis man fjerner virtual og override, og i stedet kalder metoden direkte på de afledte klasser, vil de returnere den korrekte løn for hver medarbejder:

```
foreach (HourlyEmployee hE in Init.Employees)
{
    Console.WriteLine(hE.CalculateSalary());
}
```

Det kræver, at man kender den specifikke type af objektet og det vil ikke længere være polymorfi, da alle medarbejdere ikke længere behandles som **Employee**-objekter.

I listen `List<Employee> employees` er der ogå **SalariedEmployee**-objekter, og programmet vil forsøge at caste en **SalariedEmployee** til **HourlyEmployee**, hvilket resulterer i en InvalidCastException.
Hvis man i stedet bruger en foreach-loop med `is`-operatoren:

```
foreach (var employee in Init.Employees)
{
    if (employee is HourlyEmployee hE)
    {
        Console.WriteLine(hE.CalculateSalary());
    }
    else if (employee is SalariedEmployee sE)
    {
        Console.WriteLine(sE.CalculateSalary());
    }
}
```

undersøger **is**-operatoren først, hvilken type objektet er, og derefter kaldes den den korrekte `CalculateSalary()`-metode for den specifikke type.

Hvis objektet er en **HourlyEmployee**, bliver det gemt i variablen `hE`, og `HourlyEmployee.CalculateSalary()` bliver kaldt.

Hvis objektet er en **SalariedEmployee**, bliver det gemt i variablen `sE`, og `SalariedEmployee.CalculateSalary()` bliver kaldt.

På den måde kan lønnen stadig beregnes korrekt for hver medarbejder uden virtual, override og polymorfi, men koden skal selv håndtere, hvilken type objekt der arbejdes med, og bliver derfor mere komplekst og mindre fleksibel. Med virtual og override sker det automatisk gennem polymorfi.

## Overload

### 1. Hvornår afgøres det, hvilken overload metode der skal kaldes?
Overload af metoder er, når man har flere metoder med samme navn, men forskellige parametre. Compileren afgør, hvilken metode der skal kaldes, 
baseret på antallet og typen af argumenter, der sendes til metoden. Det er forskelligt fra polymorfi, hvor den metode, der kaldes, afgøres af objektets runtime-type,
hvor det i overload afgøres af compile-time typen, og kaldes _compile-time overload resolution_.

### 2. Kunne det løses med override i stedet for overload?
Nej, ikke umiddelbart på en hensigtsmæssig måde. Override kræver, at metoden findes i base-klassen **Employee**, men bonus er kun relevant for **SalariedEmployee** og ikke for **HourlyEmployee**.
Hvis man lægger `CalculateBonus` i **Employee** for at kunne override den i **SalariedEmployee**, ville **HourlyEmployee** også arve metoden, selvom en hourly employee ikke har en bonus. 
Teknisk set kan man sagtens lave overloads af override-metoder - de to koncepter udelukker ikke hinanden, og kan godt kombineres, men overloads af metoden i SalariedEmployee ville være almindelige metoder og ikke polymorfe, da de ikke findes i base-klassen. De ville derfor heller ikke kunne bruge base.CalculateBonus() på samme måde som en override kan.