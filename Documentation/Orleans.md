# Notes about Orleans

- Serialization must not be done when communicating on the same node --> `If you’re running on a single system, Orleans can save the overhead of serializing messages. “You can just isolate messages and do a mem copy instead of real serialization, and we do that if a message is between two grains on the same machine.`
- https://thenewstack.io/project-orleans-different-than-erlang-designed-for-a-broad-group-of-developers/

Q: Are grains suitable as agents?

A(from: https://dotnet.github.io/orleans/Documentation/Frequently-Asked-Questions.html#when-should-i-use-a-grain-and-when-should-i-use-a-plain-old-object): 
"Generally, you should use a grain to model an independent entity which has a publicly exposed communication interface with other components of the system and 
that **has a life of its own** – that is, it can exist independently from other components"

Q: Why actors over OOP?

A:  “Actors represent real life better than other paradigms,” maintains Sergey Bykov from the Orleans team. “Object-oriented is close, but you’re not tightly coupled in real life.”
- Modeller expresses actions and reactions as events with cause and target
- WorldServer coordinates advancement and a traceable resultset
- Agents may also commnicate directly via MessagePassing


## Running Orleans on Docker / K8s

- https://dotnet.github.io/orleans/Documentation/Advanced-Concepts/Docker-Deployment.html#google-kubernetes-k8s
- https://github.com/dotnet/orleans/tree/master/Samples/Orleans-Docker
- https://github.com/dotnet/orleans/issues/3692