using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Pong
{
    /// <summary>
    /// The game class
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// Creates this instance
        /// </summary>
        /// <returns>The video game</returns>
        public static VideoGame Create(string[] args)
        {
             return  VideoGame
                .Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("Pong")
                        .Author("Pablo Perdomo Falcón")
                        .Description("Pong game")
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(1024, 640)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .DebugColor(Color.Red)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene
                        .Add<GameObject>(mainCamera => mainCamera
                            .Name("Camera")
                            .Tag("Camera")
                            .WithComponent<Camera>(camera => camera
                                
                                .Resolution(1024, 640)
                                .BackgroundColor(Color.Black)
                                .Build())
                            .Build())
                        .Add<GameObject>(soundTrack => soundTrack
                            .Name("Soundtrack")
                            .WithComponent<AudioSource>(audioSource => audioSource
                                
                                .PlayOnAwake(true)
                                .File("soundtrack.wav")
                                .Build())
                            .Build())
                        .Add<GameObject>(player => player
                            .Name("Player 1")
                            .Transform(transform => transform
                                .Position(-15, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(0.5f, 2.5f)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(1f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .WithComponent(new PlayerController(1))
                            .Build())
                        .Add<GameObject>(player => player
                            .Name("Player 2")
                            .Transform(transform => transform
                                .Position(15, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Kinematic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(0.5f, 2.5f)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .WithComponent<PlayerController>(new PlayerController(2))
                            .Build())
                        .Add<GameObject>(ball => ball
                            .Name("Ball")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .LinearVelocity(-5.5f, -5)
                                .Mass(10.0f)
                                .Restitution(1.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        .Add<GameObject>(downWall => downWall
                            .Name("downWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, -10)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(32, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        .Add<GameObject>(upWall => upWall
                            .Name("upWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(0, 10)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(32, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        .Add<GameObject>(leftWall => leftWall
                            .Name("leftWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(-16, 0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1, 20)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        .Add<GameObject>(rightWall => rightWall
                            .Name("rightWall")
                            .IsStatic()
                            .Transform(transform => transform
                                .Position(16, 0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(1, 20)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(true)
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build();
        }
    }
}
