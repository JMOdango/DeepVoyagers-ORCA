using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAmount : MonoBehaviour
{
    public static StoreAmount storeAmount;
    InventoryManager inventory;
    public int smallenergyamount,
    mediumenergyamount, 
    largeenergyamount, 
    mysterysnackamount, 
    magnetamount, 
    neptunestridentamount, 
    voidgemamount, 
    netamount, 
    fungiamount, 
    pocketwatchamount, 
    mermaidsorbamount, 
    basketamount;
    // Start is called before the first frame update
    public void Awake(){
        if(storeAmount == null)
        {
            storeAmount = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if(storeAmount != this){
                Destroy(this.gameObject);
            }
        }
    }

    public void restartAmount(){
        smallenergyamount = 0;
        mediumenergyamount = 0;
        largeenergyamount = 0;
        mysterysnackamount = 0;
        magnetamount = 0;
        neptunestridentamount = 0;
        voidgemamount = 0;
        netamount = 0;
        fungiamount = 0;
        pocketwatchamount = 0;
        mermaidsorbamount = 0;
        basketamount = 0;
    }

    public void getSmallEnergy(int SE){
        smallenergyamount = SE;
    }

    public void getMediumEnergy(int ME){
        mediumenergyamount = ME;
    }

    public void getLargeEnergy(int LE){
        largeenergyamount = LE;
    }

    public void getMysterySnack(int MS){
        mysterysnackamount = MS;
    }

    public void getMagnet(int M){
        magnetamount = M;
    }

    public void getNeptunesTrident(int NT){
        neptunestridentamount = NT;
    }

    public void getVoidGem(int VG){
        voidgemamount = VG;
    }

    public void getNet(int N){
        netamount = N;
    }

    public void getFungi(int F){
        fungiamount = F;
    }

    public void getPocketWatch(int PW){
        pocketwatchamount = PW;
    }

    public void getMermaidsOrb(int MO){
        mermaidsorbamount = MO;
    }

    public void getBasket(int B){
        basketamount = B;
    }
}
