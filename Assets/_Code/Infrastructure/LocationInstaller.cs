using UnityEngine;
using Zenject;

namespace _Code.Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform startPoint;
        public GameObject playerPrefab;

        public override void InstallBindings()
        {
            var playerController =  Container
                .InstantiatePrefabForComponent<PlayerController>(playerPrefab, startPoint.position, Quaternion.identity, null);

            Container
                .Bind<PlayerController>()
                .FromInstance(playerController)
                .AsSingle();
        }
    }
}