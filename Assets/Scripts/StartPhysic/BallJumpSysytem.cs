using Unity.Entities;
using Unity.Physics;
using UnityEngine;


namespace StartPhysic
{
    public class BallJumpSysytem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach(
                (ref PhysicsVelocity physicsVelocity) =>
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                        physicsVelocity.Linear.y = 5;
                });
        }
    }
}
