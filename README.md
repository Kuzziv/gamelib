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

- [x] Documentation with Doxygen.
  - XML comments throughout your library to provide comprehensive documentation.

- [x] The library needs to use LINQ.
  - The LootSystem uses LINQ for various operations, such as finding bags containing specific items, filtering items based on certain criteria, and performing queries on collections of bags and items to retrieve useful information.

- [x] The library needs to implement at least three C# design patterns:
  - Observer pattern for characters, depending on what terrain they are on, then get a bonus or a debuff.
    - IObserver interface defines the contract for observers, specifying the Update() method.
    - ISubject interface defines the contract for subjects, specifying methods to attach, detach, and notify observers.
    - CharacterBase class implements the ISubject interface, making it a subject that can be observed.
    - Both Player and NPC classes implement the IObserver interface, making them observers of CharacterBase objects.
    - When a character's terrain type changes, the subject notifies all observers, which then update their state based on the new terrain type.


  - Factory pattern for creating characters, depending on what type of character you want to create.
  - Composite pattern for LootSystem to be able to have a bag that can contain other bags or items.
    - Compoent: The Component interface defines the common interface for all objects in the composition, whether they are composite or leaf elements. In our example, IItem serves as the component interface, defining common properties and methods that both individual items and composite items must implement.
    - Leaf: The Leaf represents the end objects in the composition, which do not have any children. In our example, Weapon and Consumable classes serve as leaf elements because they are individual items that cannot contain other items. They implement the IItem interface but do not contain other items.
    - Composite:The Composite represents objects that contain other objects, either leaf or composite. In our example, the Bag class serves as a composite because it can contain other items (Weapon, Consumable) as well as other bags (Bag). It implements both the ILootable and ICompositeItem interfaces, allowing it to contain and manage a collection of items.
    - To summarize:
      - Component: IItem interface
      - Leaf: Weapon and Consumable classes
      - Composite: Bag class 

      
  -Singleton Pattern:
    - YamlFileLogger and TraceLogger are both singletons.
      - Private constructor to prevent instantiation from other classes.

      
  - Decoracter pattern:
    - LogLevelFilter is a "decorater" pattern, that can be used to filter out log/trace levels, depending on what is set in the config file.
      - Interface (Component): The ILogger interface defines the basic operations for logging messages (LogInformation, LogWarning, LogError, LogException).
      - Concrete Component: The YamlFileLogger and TraceLogger classes implement the ILogger interface directly. They represent the core logging functionality without any filtering.
      - Decorator:
        The LogLevelFilter class acts as a decorator. It also implements the ILogger interface but adds additional behavior to filter log messages based on the specified log level.
        LogLevelFilter takes another ILogger object as a parameter in its constructor, representing the wrapped logger.
        LogLevelFilter intercepts calls to logging methods (LogInformation, LogWarning, LogError) and checks if the log level specified in its constructor allows logging at that level. If so, it delegates the logging operation to the wrapped logger.




- [x] MsTesting to insure that everything works
  - [x] Config
  - [x] CharacterFactory
  - [x] Logging
  - [x] LootSystem


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
    - Consumable.cs
  - Services
    - LootSystem.cs
```

