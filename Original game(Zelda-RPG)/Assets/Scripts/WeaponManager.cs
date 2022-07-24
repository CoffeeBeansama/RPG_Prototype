using UnityEngine;

namespace Samurai
{
    public class WeaponManager : MonoBehaviour
    {
        public KeyCode ChooseMeleeState = KeyCode.Alpha1;
        public KeyCode ChooseRangeState = KeyCode.Alpha2;
        private Throwables ThrowablesManager;
        public bool MeleeState;
        public bool RangeState;
        public WeaponsList[] weaponsList;
        
        private GameObject Slime;
        public bool IsUsingaMeleeWeapon;

        private void Awake()
        {
            Slime = GameObject.FindGameObjectWithTag("Player");
            ThrowablesManager = GetComponent<Throwables>();
        }

        private void Start()
        {
            MeleeState = true;
        }


        private void Update()
        {
            if(Input.GetKeyDown(ChooseMeleeState))
            {
                MeleeState = true;
                RangeState = false;
            }

            if(MeleeState)
            {
                if(Input.GetKeyDown(KeyCode.Space) && !IsUsingaMeleeWeapon)
                {
                    foreach(WeaponsList Meleeweapons in weaponsList)
                    {
                    IsUsingaMeleeWeapon = true;
                    Instantiate(Meleeweapons.MeleeWeapons[0],Slime.transform.position,Quaternion.identity);
                    
                    }
               }

            }

            if(Input.GetKeyDown(ChooseRangeState))
            {
                RangeState = true;
                MeleeState = false;
            }

            
            if(RangeState)
            {
                if(Input.GetKeyDown(KeyCode.Space) && !IsUsingaMeleeWeapon && !ThrowablesManager.InventoryisEmpty())
                {
                    foreach(WeaponsList RangeWeapons in weaponsList)
                    {
                        IsUsingaMeleeWeapon = false;
                        Instantiate(RangeWeapons.RangeWeapons[0],Slime.transform.position,Quaternion.identity);
                       
                    }
                }

                

            }


            
        }

    
    }

}

