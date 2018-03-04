# LIFE-X Development

This repository contains the new LIFE-X simulation engine, prototypes and documentation

![alt text](https://gitlab.informatik.haw-hamburg.de/mars/LIFE-X/raw/master/images/IMG_5332.jpg "Logo Title Text 1")

### ToDo

1. Show conceptional model (layers with ACCEPTS and PRODUCES lists)
2. Show example model for non-trivial scenario (KNP or urban?)
3. Show architecture of system
4. Get Feedback from Modellers
 4.1 Get Feedback on wording and naming from modelles (Subscribe, Retrieve etc)
5. Expand requirements list

Unsorted:
- Where/How do we describe Physical laws of the environment

### Brainstorming

#### Runtime Environment
- Double Buffering:
 - Nodes may calculate t+1 ticks in advance
 - Every agent is at most 1 tick ahead of every other agent
 - Whenever an agent calls another agent the current tick is passed
 - When current tick in an incoming message is smaller than my own tick the message is held back until my current tick equals the incoming message’s tick
- „One cannot decide to not be dead"
- „This is like round-based combat in Baldur's Gate“
    - round-based
    - authorative modeller-customised World-Layer (could be called the "scenario")

#### Simulation Initialization

- decouple by Orleans Client
  - may be self-implemented
  - may be enriched by MARS helper methods and components (i.e. OSM-Loader)
- SimulationConfig required, but has sensible defaults!

#### Agents

- Messages propagated to the agent must be correct in terms of causality and order (i.e. an agent must not get a message from the future****)
- Values are retrieved by RetrieveValue() method
 
#### Environment
- Agents send actions to WorldServer
- WorldServer features Pub/Sub mechanism to inform other Layers and thus agents about new events
 - This particularly annihilates the requirement for tight coupling agent types and layers 

The virtual environment plays an essential role in a simulation. It:
- supplies the “physical” conditions for the virtual agents to exist
- provides agents with information about their surrounding
- enforces physical laws
- Researchers have stated that virtual environments should be decoupled from agents and be treated as a first class entity in MABS

- Define function of .Memory()! Last received events?  

##### Openness:
- virtual agents should only access the environmental information they they can perceive
- the effect of an action or event in the environment should not be known with certainty in advance
- the environment should not be static but should undergo changes as a result of actions or events
- the environment states should not be enumerable