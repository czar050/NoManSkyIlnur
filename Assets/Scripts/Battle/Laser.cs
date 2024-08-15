using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NoManSky
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, IWeapon
    {
        public float _maxDistance = 100.0f;
        [SerializeField] private float DamageAmount = 5f;
        private DataWeaponExtrinsic _dataWeaponExtrinsic;
        private Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float _waitTimeFiring = 0.1f;
        [SerializeField] private bool _canFire;
        [SerializeField] private float _lineRenAnimSpeed = 1f;
        [SerializeField] private float _lineRenAnimDelta = 0f;
        [SerializeField] private LineRenderer _lineRenderer;
        private ShipWeapons _shipWeapons;
        public List<IDamageable> TargetHit = new List<IDamageable>();

        private void Awake()
        {
            if (_shipWeapons == null)
                _shipWeapons = GetComponentInParent<ShipWeapons>();
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();
        }
        private void Start()
        {
            _waitForFiring = new WaitForSeconds(_waitTimeFiring);

            _lineRenderer.enabled = false;
            _canFire = true;
        }

        private void Update()
        {
            if (!_lineRenderer.enabled) return;
            _lineRenderer.SetPosition(0, transform.position);

            _lineRenAnimDelta += Time.deltaTime;
            if(_lineRenAnimDelta > 1.0f)
                _lineRenAnimDelta = 0f;

            _lineRenderer.material.SetTextureOffset("_MainTex", new Vector2(_lineRenAnimDelta * _lineRenAnimSpeed, 0f));
        }

        public void Initialize(DataWeaponExtrinsic dataWeaponExtrinsic)
        {
            _dataWeaponExtrinsic = dataWeaponExtrinsic;
        }

        public Vector3 FireWeapon(Vector3 targetPosition)
        {
            if (!_canFire) return Vector3.zero;
            RaycastHit hitInfo;
            var direction = targetPosition - transform.position;
            if (Physics.Raycast(transform.position, direction, out hitInfo, _maxDistance))
            {
                var targetHit = hitInfo.transform;
                if (targetHit != null)
                {
                    Debug.Log($"FireWeapon.targetHit: {targetHit.name}");
                    var damageableHit = targetHit.GetComponent<IDamageable>();
                    if (damageableHit != null)
                    {
                        TargetHit.Add(damageableHit);
                        Damage(DamageAmount, targetHit.position, _dataWeaponExtrinsic.GameAgent);
                    }
                    VizualizeFireWeapon(targetHit.position);
                    return targetHit.position;
                }
            }
            VizualizeFireWeapon(transform.position + direction.normalized * _maxDistance);
            return targetPosition;
        }

        private void Damage(float _damageAmount, Vector3 targetHitPosition, GameAgent sender)
        {
            foreach (var targetHit in TargetHit)
            {
                targetHit.ReceiveDamage(_damageAmount, targetHitPosition, sender);
            }
            TargetHit.Clear();
        }
        public void VizualizeFireWeapon(Vector3 targetPosition)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, targetPosition);
            _canFire = false;
            _coroutineFiring = StartCoroutine(FiringCor());
        }

        private IEnumerator FiringCor()
        {
            yield return _waitForFiring;
            _canFire = true;

            yield return _waitForFiring;
            if(_canFire)
            _lineRenderer.enabled = false;
        }
    }
}