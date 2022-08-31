using Unity.Burst;
using Unity.Entities;
using Unity.Physics;

namespace TestTriggers
{
    [BurstCompile]
    public struct TriggerJob : ITriggerEventsJob
    {
        public ComponentDataFromEntity<PhysicsVelocity> physicsVelocityEntities;
        public void Execute(TriggerEvent triggerEvent)
        {
            if( physicsVelocityEntities.HasComponent(triggerEvent.EntityA))
            {
                PhysicsVelocity physicsVelocity = physicsVelocityEntities[triggerEvent.EntityA];
                physicsVelocity.Linear.y = 5;
                physicsVelocityEntities[triggerEvent.EntityA] = physicsVelocity;
            }

            if( physicsVelocityEntities.HasComponent(triggerEvent.EntityB))
            {
                PhysicsVelocity physicsVelocity = physicsVelocityEntities[triggerEvent.EntityB];
                physicsVelocity.Linear.y = 5;
                physicsVelocityEntities[triggerEvent.EntityB] = physicsVelocity;
            }
        }
    }
}