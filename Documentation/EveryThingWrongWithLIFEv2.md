# Everything Wrong With LIFEv2 

## Execution

### General

- No Logging System throughout LIFE
- All configuration should be provided by the environment (-> 12factor.net). That includes
files like ResultConfig, SimConfig etc.

### Initialization & Setup

- NodeRegistry irrelevant by now
- No local start possible without Cloud-Connect

### Network

- Serialization uses JSON.NET (historical: BinarySerializer as fallback for everything wasn't avialable in early versions of .NET Core)
Should better use Protobuf or MsgPack 
- Usage of IPv6 MultiCast Groups could yield huge advancement in network efficiency


### Simulation Distribution

- Distribution Config still needs to be provided manually as JSON file
- No dynamic redistribution
- Tick is provided by central component (investigate elastic tick or optimistic advancement)
 

## Modelling / LIFE API

### Agents

- Sense, Reason, Act too magically hidden. Sense returns IInteraction, which requires modeller to know about composite patterns etc
to create multi-action returns
- Property / Attribute definition undefined (can be anything, should be C# Properties)
- Constructor Initialization is not intuitive
- Contract for ctor init is not clear. Which parameter types are automatically set, which are not?
- Inconsistency of contracts for certain features. I.e. ResultOutput can be configured via implementing ISimResult
or through the ResultConfigDialog on the website. Not really documented, which takes precedence and also not too many
options available for the ISimResult method.```public class Elephant : GeoAgent<Elephant>, IElephant, ISimResult```
- Base constructor must to be called! Behavior unclear! Some variables simply get put through, others must not: 
 
```csharp
public Elephant
        (IKnpElephantLayer layer,
            RegisterAgent registerAgent,
            UnregisterAgent unregisterAgent,
            GeoGridEnvironment<GeoAgent<Elephant>> environment,
            IWaterPotentialLayer waterPotentialLayer,
            IKNPObstacleLayer obstacleLayer,
            IVegetationLayer vegetationLayer,
            IKNPTreeLayer treeLayer,
            ITemperatureTimeSeriesLayer temperatureTimeSeriesLayer,
            IShadeLayer shadeLayer,
            Guid id,
            double lat,
            double lon,
            int herdId,
            string elephantType,
            bool isLeading,
            string reproductionYears)
            :
            base(
                layer,
                registerAgent,
                unregisterAgent,
                environment,
                new GeoCoordinate(lat, lon),
                id.ToByteArray()
            )
```
- Dynamic switch between certain layers, requires code change / is not simply a configuration:

```csharp
//assign layer from which the elephant receives information about water
waterSources = new WaterSources
	(_elephantLayer.UsePotentialFieldLayer,
	    waterPotentialLayer);

// Leading elephant knows about surrounding waterpoints
if (Leading)
{
	waterSources.AddInitialWaterSource(lat, lon);
}
```

 
## Environment

- Performance of GeoGridEnvironment in some setups very poor (too small or too tiny grid size probably, results too many lookups)
- Way too many different environments to choose from. 
- No distributable environment!
- Many different environment APIs
- No clear concept for the distinction of Agents and Environment
- Environment is purely passive, no enforcement of physical laws etc
- Queries need to be performance optimized by the modeller!
- Environment is pull-based, should be push-based / pub-sub
