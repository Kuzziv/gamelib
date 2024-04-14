# gamelib

In order to pass this AWSC class, you need to build a game library. The game itself needs to be turn-based.

## Requirements Checklist

- [x] There needs to be a configuration file, and the config file should be used for something.
  - I use it to set the log level and trace level, and depending on what it's set, the logger then logs the following settings.

- [x] The library needs to use logging and tracing.
  - I have built a custom logger and tracer that can be used throughout the library.

- [x] The library needs to follow the SOLID principles:
  - Single Responsibility Principle
  - Open/closed Principle
  - Liskov Substitution
  - Interface Segregation
  - Dependency inversion
  - I have used SOLID throughout the whole library.

- [ ] Documentation with Doxygen.
  - XML comments throughout your library to provide comprehensive documentation.

- [x] The library needs to use LINQ.
  - The LootSystem uses LINQ for various operations, such as finding bags containing specific items, filtering items based on certain criteria, and performing queries on collections of bags and items to retrieve useful information.

- [x] The library needs to implement at least three C# design patterns:
  - Observer pattern for characters, depending on what terrain they are on, then get a bonus or a debuff.
  - Factory pattern for creating characters, depending on what type of character you want to create.
  - Composite pattern for LootSystem to be able to have a bag that can contain other bags or items.
  - Singleton pattern for the logger/tracing, so that there is only one instance of the logger/tracing.

## File Structure

```
- Config
  - Models
    - AppConfig.cs
  - Services
    - ConfigLoader.cs

- CharacterFactory
  - Models
    - CharacterBase.cs
    - NPC.cs
    - Player.cs
  - Services
    - ICharacterFactory.cs
    - NPCFactory.cs
    - PlayerFactory.cs
    - ISubject.cs
    - IObserver.cs

- Logging
  - Models
    - LogEntry.cs
    - LogLevel.cs
  - Services
    - ILogger.cs
    - LogLevelFilter.cs
    - TraceLogger.cs
    - YamlFileLogger.cs
    - CombinedLogger.cs

- Engine
  - Services
    - GameEngine.cs

- GameEnvironment
  - Models
    - TerrainType.cs
    - World.cs

- LootSystem
  - Models
    - ILootable.cs
    - IItem.cs
    - Weapon.cs
    - Bag.cs
  - Services
    - LootSystem.cs
```

## Updates

- Implemented the Singleton pattern for the logger/tracing functionality to ensure only one instance exists throughout the application.
- Added documentation for clarity and understanding.
- Organized the file structure according to the specified requirements.