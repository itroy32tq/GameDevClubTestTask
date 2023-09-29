using Script.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Script.Inventoty;
using Script.ItemSpace;
using Script.Interfaces;
using Script.Configurations;
using Script.Structs;
using System.Collections.Generic;

namespace PoketZone
{
    public class PlayerController : Unit, ICanTakeItem
    {
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private VariableJoystick _joystick;
        [SerializeField] private Button _shootButton;
        [SerializeField] private UIInventory _playerInventory;
        [SerializeField] private SpriteRenderer _weaponSpriteRenderer;
        [SerializeField] private SpriteRenderer _playerSpriteRenderer;
        [SerializeField] private PlayerConfiguration _playerConfiguration;

        private Vector2 _shootDerection = Vector2.right;
        private ItemInfo _currentweapon;
        public ItemInfo CurrentWeapon => _currentweapon;
        public InventoryWithSlots InventoryModel => _playerInventory.InventoryModel;
        public event Action<object, Item> OnTakeItemOnMapEvent;
        protected override void Start()
        {
            //todo
            base.Start();
            _shootButton.onClick.AddListener(OnShootButtonClick);

            Init(_playerConfiguration);

        }
        private void Init(PlayerConfiguration configuration)
        {
            //������� ���������
            _playerInventory.InitUIInventory(_playerConfiguration.BaseParams.InventoryCapacity, this);
            _playerInventory.FillSlots(_playerConfiguration.BaseInventoryItems);
            //�������������, �������� � �������� ���������
            transform.position = configuration.Location;
            Health = configuration.BaseParams.MaxHealth;
            Speed = configuration.BaseParams.MoveSpeed;
            //������ ���������
            var weaponInfo = GameManager.Instance.GetAssetForId(configuration.CurrentWeaponId);
            SetCurentWeapon(weaponInfo);
        }

        private void OnShootButtonClick()
        {
            //�� ������� �� ������� ���� �� ������ ��������������� ��������
            weaponController.Shoot(_shootPoint.position, GetShootDirection());
        }
        private void Update() 
        {
            MakeMove(_joystick.Direction);
        }
        private void SetCurentWeapon(ItemInfo weapon)
        {
            _currentweapon = weapon;
            weaponController.ConfigureWeapon(_currentweapon);
            _weaponSpriteRenderer.sprite = weaponController.Weapon.SpriteIcon;
            _weaponSpriteRenderer.sortingOrder = _playerSpriteRenderer.sortingOrder + 1;
        }

        private Vector2 GetShootDirection()
        {
            if (_shootDerection == Vector2.right)
                return Faceing;
            //todo
            return _shootDerection;
        }

        public void TakeItem(Item item)
        {
            _playerInventory.FillSlots(new List<ItemsData>(){new ItemsData(item.Info.Id, item.State.Amount)});
        }
    }
}
