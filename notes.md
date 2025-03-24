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