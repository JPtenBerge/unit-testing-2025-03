# Notes

## "integration test"

- "iets aan het integreren"
- database
- API aanspreken - HTTP => endpoint
- HTML renderen
- mailserver
- andere servers...

## Testframeworks

- MSTest => `[TestMethod]`
- xUnit => `[Fact]`/`[Theory]` (data-driven test)
- NUnit => `[Test]`

verschil? syntax. attributes.

vroegah meer verschillen:
- data-driven tests
- .NET Core 1.0 - MSTest werd niet ondersteund

## Wat is een unit?

"unit" - kleinst mogelijk ding wat je kan testen

Zijn dit units?

- `private` MagicHelper in zelfde class - PRIMA
- `public` MagicHelper in zelfde class - PRIMA
- `andereInstance.MagicHelper()` in andere class - niet ok
- `static AndereClass.MagicHelper` - PRIMA
- `MagicHelper` onderdeel van .NET - PRIMA
- `MagicHelper` onderdeel van .NET wat een webservice in Zweden aanroept - niet ok

Static zaken die men graag wil mocken:

- `DateTime.Now`
- `File.AppendAllTextAsync()`
- `Logger.Log()`

`private` testen? Liever niet. Maar het kan wel middels reflection/`[InternalsVisibleTo()]`

## Methodenamen

```cs
// FunctieDieJeTestResultaat()
// WatBeginStaatVerwachteResultaat()
// AddPositiveNumbersShouldAddEverything()

// given-when-then
// arrange-act-assert
// AddWithPositiveNumbersShouldAddEverything()
// Add_PositiveNumbers_AddEverything()
// Add_With_Positive_Numbers_Should_Really_Do_Something_Special()
```

## Test-driven development (TDD)

Eerst test dan pas functie/methode

1. Schrijf een test
2. Run de test en zie dat hij FAALT
3. Schrijf code / implementeer
4. Run de test/alle tests en zie dat hij SLAAGT
5. Refactor

Repeat. RED-GREEN-REFACTOR

voordelen TDD?

- forceert je om testbare code te schrijven
- wat je schrijft, doet wat je wil
- forceert je om meer/beter na te denken over je implementatie
- 1 test voor elk detail => uitvoerbare documentatie
- tests niet lijden onder deadlinestress

wanneer geen TDD?

- deadline halen
  - dit mag niet een structureel argument worden
- wanneer de architectuur een hoop vraagtekens heeft

bug?
=> schrijf een test die de bug reproduceert
=> fix

## Mutation testing

- waarden veranderen
- statements
- CODE VERANDEREN
- "test your tests"
- 100% mutation score? pacemaker.

```cs
// productiecode
if (x > 4) { ... }

// mutanten
if (x > 4000) { ... }
if (x < 4) { ... }
if (x >= 4) { ... }
if (x == -4) { ... }
```

STRYKER
- naam komt origineel van X-Men, dude die alle mutanten af wil maken

## Verder

- [Visual Studio edities](https://visualstudio.microsoft.com/vs/compare/): testondersteuning is buiten de Enterprise-editie vrij karig. Geen live unit testing, geen Microsoft Fakes (static zaken mocken), zelfs geen code coverage.
- [Awesome Assertions](https://awesomeassertions.org/) voor leesbare/makkelijkere assertions, zeker bij objecten/collections vergelijken
- [Bowling Kata](https://codingdojo.org/kata/Bowling/) voor TDD

## Testcontainers

- mini-VMs
- Docker
- zeer waardevol bij integratietesten
  - database
  - mailserver
  - SMS-server
  - webserver
