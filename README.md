# gamelib

In order to pass this AWSC class you need to build a game library, the game it's self need to be turn based.


[x]
* There needs to be a configuration file, and the config file, should be use for something.
- I use it to set the log level and trace level, and depending on what it's set. the logger then logs the following setting.


[x]
* The library needs to use logging and tracing.
- I have build a custom logger and tracer that can be use though out the library.


[]
* The library needs to follow the SOLID principles
* Single Responsibility Principle
* Open/closed Principle
* Liskov Substitution
* Interface Segregation 
* Dependency inversion
- I have used SOLID though out the hole library


[]
* Documentation with doxygen 
- XML comments throughout your library to provide comprehensive documentation


[]
* The library needs to use linq
- 


[]
* The library needs to Implementat at lest three C# design patterns
- Observer pattern for characters, depending on what terrain they are on, then get a bouns or a debuff.
- Factory pattern for creating characters, depending on what type of character you want to create.
- Composite pattern for LootSystem to be able to have a bag that can contain other bags or items.


the file structure should look like this

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

