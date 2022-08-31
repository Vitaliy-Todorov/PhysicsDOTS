using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

namespace TestTriggers
{
    public partial class TestTriggers : SystemBase
    {
        private StepPhysicsWorld stepPhysicsWorld;
        private EndSimulationEntityCommandBufferSystem commandBufferSystem;

        protected override void OnCreate()
        {
            stepPhysicsWorld = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<StepPhysicsWorld>();
            commandBufferSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            TriggerJob job = new TriggerJob
            {
                physicsVelocityEntities = GetComponentDataFromEntity<PhysicsVelocity>()
            };

            Dependency = job.Schedule(stepPhysicsWorld.Simulation, Dependency);
            commandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}