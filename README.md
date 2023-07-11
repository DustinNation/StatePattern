# StatePattern
Head First Design Patterns Chapter 10

The State Pattern allows an object to alter its behavior when its internal state changes. The object will appear to change its class.
-ie this pattern encapsulates state-based behavior and delegates behavior to the current state.

** The State Pattern allows an object to have many different behaviors that are based on its internal state.

** Unlike a procedural state machine, the State Pattern represents each state as a full-blown class.

** The Contextr gets its behavior by delegating to the current state object it is composed with.

** By encapsulating each state into a class, we localize any changes that will need to be made.

** The State and Strategy Patterns have the same classs diagram, but they differ in intent (the Strategy Pattern typically configures Context classes with a behavior or algorithm.)

** The State Pattern allows a Context to change its behavior as the state of the Context changes.

** State transitions can be controlled by the State classes or by the Context classes.

** Using the State Pattern will typically result in a greater number of classes in your design.

** State classes may be shared among Context instances.
