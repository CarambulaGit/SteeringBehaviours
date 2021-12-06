using Project.Interfaces;
using UnityEngine;

namespace Project.Scripts {
    public abstract class CanBeKilledController : MonoBehaviour, ICanBeKilled {
        public abstract void Die();
    }
}