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
* The library needs to Implementat at lest three design patterns
- 


- Config
  - Models
    - AppConfig.cs
  - Services
    - ConfigLoader.cs
- Logging
  - Services
    - ILogger.cs
    - LogLevelFilter.cs
    - TraceLogger.cs
    - YamlFileLogger.cs
- Tracing
  - Services
    - ITracer.cs
    - TraceLevelFilter.cs
    - YourTracerImplementation.cs
- Game
  - Models
    - Character.cs
    - GameState.cs
    - GameEvent.cs
    - ...
  - Services
    - GameManager.cs
    - GameFactory.cs
    - GameValidator.cs
    - ...
- Utils
  - LinqUtils.cs
  - ...
