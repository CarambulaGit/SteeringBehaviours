using System;
using System.Collections;
using Project.Classes;
using UnityEngine;

namespace Project.Scripts {
    public class WeaponController : MonoBehaviour {
        private const float RayShowingTime = 0.02f;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Weapon weapon;

        public Weapon Weapon => weapon;

        private void Awake() {
            weapon.ReloadImmediately();
        }

        private void Update() {
            HandleInput();
        }

        private void HandleInput() {
            if (Input.GetButton("Fire1")) {
                Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                weapon.ReloadTask();
            }
        }

        private void Shoot() {
            var position = transform.position;
            var shot = weapon.TryShoot(position, transform.rotation, out var rays);
            if (shot != Weapon.ShotResult.ShotSuccessful) return;
            foreach (var ray in rays) {
                StartCoroutine(CheckForHit(ray, out var hitPoint)
                    ? AnimateShoot(ray.origin, hitPoint)
                    : AnimateShoot(ray.origin, ray.GetPoint(weapon.MaxShotDistance)));
            }
        }

        private bool CheckForHit(Ray2D ray, out Vector3 hitPoint) {
            hitPoint = Vector3.zero;
            var hit = Physics2D.Raycast(ray.origin, ray.direction, weapon.MaxShotDistance,
                LayerMask.GetMask(Consts.ANIMAL_LAYER_NAME));
            if (hit.collider == null || !hit.collider.TryGetComponent<Animal>(out var animal)) return false;
            hitPoint = hit.point;
            animal.Die();
            return true;
        }

        private IEnumerator AnimateShoot(Vector3 startPos, Vector3 finishPos) {
            var line = Instantiate(lineRenderer);
            line.SetPosition(0, startPos);
            line.SetPosition(1, finishPos);
            line.enabled = true;
            yield return new WaitForSeconds(RayShowingTime);
            line.enabled = false;
            Destroy(line.gameObject);
        }
    }
}