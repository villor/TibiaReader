# TibiaReader
Memory reader for the Tibia game client

## About
TibiaReader is a .NET class library that can be used to find running Tibia clients and read values from their memory.

The library can currently read the following values from clients of version 10.91:
* Health
* Maximum Health
* Mana
* Maximum Mana

More will be added in the future!

## Usage
Here is an example of how TibiaReader can be used:

```c#
var tibiaClients = TibiaClient.GetClients();

foreach (var tibia in tibiaClients)
{
    Console.WriteLine("Client: " + tibia.WindowTitle);
    Console.WriteLine("HP: {0}/{1}", tibia.Health, tibia.MaxHealth);
    Console.WriteLine("Mana: {0}/{1}\n", tibia.Mana, tibia.MaxMana);
}
```

## License
TibiaReader is licensed under the MIT license.
