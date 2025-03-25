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
