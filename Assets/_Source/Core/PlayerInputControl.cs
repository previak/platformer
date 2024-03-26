using UnityEngine;

namespace _Source.Core
{
    public class PlayerInputControl : MonoBehaviour
    {
        private Rigidbody2D _rigidBody2D = null;
        private Animator _animator = null;
        private SpriteRenderer _spriteRenderer = null;

        [SerializeField] private float maxSpeed = 6;
        [SerializeField] private float maxDistanceToGround = 0.1f;
        [SerializeField] private LayerMask groundLayer = 1;
        [SerializeField] private float jumpPower = 10;
        [SerializeField] private float jumpGravityScale = 1;

        private float _baseGravityScale;
        private bool _jumpButtonDown = false;
        private bool _jumpButtonUp = false;

        private void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _baseGravityScale = _rigidBody2D.gravityScale;

            _animator = GetComponent<Animator>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
            _jumpButtonDown |= Input.GetButtonDown("Jump");
            _jumpButtonUp |= Input.GetButtonUp("Jump");
        }

        private void FixedUpdate()
        {
            var motion = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, _rigidBody2D.velocity.y);

            if (motion.x == 0)
            {
                _animator.SetBool("isWalking", false);
            }
            else
            {
                _animator.SetBool("isWalking", true);
                _spriteRenderer.flipX = motion.x > 0;
            }

            var groundHit = Physics2D.Raycast(transform.position, Vector2.down, maxDistanceToGround, groundLayer);
            if (groundHit)
            {
                _animator.SetBool("isGrounded", true);

                if (_jumpButtonDown)
                {
                    motion.y = jumpPower;
                    _rigidBody2D.gravityScale = jumpGravityScale;
                    _jumpButtonDown = false;
                    _jumpButtonUp = false;
                }
            }
            else
            {
                _animator.SetFloat("verticalSpeed", motion.y);
                if (motion.y < 0 || _jumpButtonUp)
                {
                    _rigidBody2D.gravityScale = _baseGravityScale;
                    _jumpButtonUp = false;
                }

                _animator.SetBool("isGrounded", false);
                _animator.SetBool("isWalking", false);
            }

            _rigidBody2D.velocity = motion;
        }
    }
}