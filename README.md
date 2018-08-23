# gs-tools
Guiosoft .net tools

## Log Class

Register your journalized informations in text files.

## Extensions

### String

Extensions functions of string conversion/processing

* string.ContainsOne = Check if string has at least one of the itens
* string.JustNumbers = Remove non-numeric characters from string
* string.PhoneNumber = Telephone number format (Brazil)
* string.RemoveAccents = Remove(replace) accents (diacritcs) from string
* string.ToDate = Parse an string to Date, using various formats
* string.ToDateTime = Parse an string to DateTime, using various formats
* string.ToDecimal = Convert string to decimal checking for decimal point
* string.ToDouble = Convert string to double checking for decimal point
* string.ToInt = Parse text to int
* string.ToTime = Convert string to Time (DateTime)

### Numbers

* (decimal/double).Equivalent = Check if two decimal/double numbers are equals considering precision
* (int/decimal/double).IsBetween = Check if int/decimal/double number is in range
* (int/decimal/double).ForceInterval = Force int/decimal/value value in interval
* (decimal/double).IsZero = Check if decimal/double value is about zero (precision = 2)
* (int/long).ToBytes = Format size to multiples of Byte
* (decimal/double).ToInvariantString = Returns double to string with invariant decimal separator