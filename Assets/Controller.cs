
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

namespace Coffee
{

    public class Controller : MonoBehaviour
    {
        public TMP_Text beanbuyerText, espressoText, potsText, bbuyerButtonText, storeText, storesButtonText, moneyText, beansText, beansSell, espressoButtonText, potButtonText, ePriceText, cPriceText, ovensText, ovensButtonText,pastryMod, moneyModText, pumpButtonText;

        public TMP_Text coffeeN, espressoN, latteN, frappeN, sconeN, storeN, brewerN, EssMachN, OvenN, beanBuyN, milkBuyN, steamerN, blenderN, iceMakerN, pumpN, beansN, milkN, iceN, lPriceText, milkCount, steamerText, steamerButtontext, iceButtonText, iceCountText,
            fPriceText,sPriceText, milkBuyerPT, iceMakerPT, steamerPT, blenderPT, pumpPT, milkNT, iceNT, sconesNT, milkBuyerButtonText, blenderButtonText, salesText, boxTitle, beanModText, milkModText, iceModText, pastryStock, pastryStockText;
        int coffees, espressos, lattes, mochas, frappes, scones, muffins, bagels, shots, profit;
       int coffeeSold, espressoSold, latteSold, mochaSold, frappeSold, sconeSold, muffinSold, bagelSold, shotSold;
        double CPrice, EPrice, moneyMod, LPrice, FPrice, SPrice;
        private System.Random rnd = new System.Random();
        public Data data;
        private double ppg = 10;

        public GameObject storeButton, brewerButton, espressoButton, ovenButton, beanBuyerButton, milkBuyerButton, blenderButton, pumpButton, steamerButton, iceMakerButton, beanButton;
        float rate = 1;
        public void Start()
        {
            data = new Data();
            StartCoroutine(Print(rate));
           // InvokeRepeating("UpdateStats", 1f, 1f);
            CPrice = 2.00;
            EPrice = 3.00;
         
            LPrice = 5.00;
            FPrice = 8.00;
            SPrice = 2.00;
            cPriceText.text = "$ " + CPrice;
            ePriceText.text = "$ " + EPrice;
            lPriceText.text = "$ " + LPrice;
            sPriceText.text = "$ " + SPrice;
            


            Disable(beanbuyerText, espressoText, potsText, bbuyerButtonText, storeText, storesButtonText, moneyText, beansText, beansSell, espressoButtonText, potButtonText, ePriceText, cPriceText, ovensText,
                ovensButtonText, pastryMod, moneyModText, coffeeN, espressoN, latteN, frappeN, sconeN, storeN, brewerN, EssMachN, OvenN, beanBuyN, milkBuyN,
                steamerN, blenderN, iceMakerN, pumpN, milkN, iceN, fPriceText, sPriceText,  milkBuyerPT, iceMakerPT, steamerPT, blenderPT, pumpPT, milkNT,
                iceNT, milkBuyerButtonText, sconesNT, sPriceText, sconeN, milkModText, iceModText, lPriceText, pastryStock, pastryStockText);

            Enable(moneyModText, moneyText, cPriceText, potButtonText, potsText, beansText, beansSell, coffeeN, brewerN, storeN, beansN, storesButtonText, storeText);
            storeButton.SetActive(false);
            espressoButton.SetActive(false);
            ovenButton.SetActive(false); ;
            beanBuyerButton.SetActive(false);
            milkBuyerButton.SetActive(false);
            blenderButton.SetActive(false);
            pumpButton.SetActive(false);
            steamerButton.SetActive(false);
            iceMakerButton.SetActive(false);
            salesText.text = "Coffees: " + coffeeSold + " Espressos: " + espressoSold + " Lattes: " + latteSold +" Frappes: " + frappeSold +  " Pastries: " + sconeSold;
            boxTitle.text = "Sales";
            beanModText.text = "+0";

        }
        IEnumerator Print(float time)
        {

            while (true)
            {
                yield return new WaitForSeconds(time);
                Debug.Log("Method is executed");
                UpdateStats();
                time = rate;
            }
        }
        public void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
            //updateMods();
            revealText();
            //set texts
            beanbuyerText.text = data.beanBuyer.Amount.ToString();
            espressoText.text = data.espressoM.Amount.ToString();
            potsText.text = data.pots.Amount.ToString();

            bbuyerButtonText.text = "$ " + numToString(data.beanBuyer.Cost);
            storeText.text = numToString(data.stores.Amount);
            storesButtonText.text = "$ " + numToString(data.stores.Cost);
            moneyText.text = "$ " + numToString(data.money);
            beansText.text = numToString(data.beans.Amount);
            beansSell.text = "$" + Math.Round(ppg, 2);
            espressoButtonText.text = "$ " + numToString(data.espressoM.Cost);
            potButtonText.text = "$ " + numToString(data.pots.Cost);
          
            fPriceText.text = "$ " + Math.Round(FPrice, 0);

            if ((data.beans.Mod + data.beanBuyer.Amount * 10 )< 0)
            {
                beanModText.text = (numToString(data.beans.Mod + data.beanBuyer.Amount*10));
            }
            else {
                beanModText.text = "+"+(numToString(data.beans.Mod + data.beanBuyer.Amount * 10));
            }

            if (data.milk.Mod< 0)
            {
               milkModText.text = numToString(data.milk.Mod );
            }
            else
            {
                milkModText.text = "+" + numToString(data.milk.Mod);
            }

            if (data.ice.Mod < 0)
            {
                iceModText.text = numToString(data.ice.Mod);
            }
            else
            {
                iceModText.text = "+" + numToString(data.ice.Mod);
            }

            if (data.scones.Mod < 0)
            {
                pastryMod.text = numToString(data.scones.Mod);
            }
            else
            {
                pastryMod.text = "+" + numToString(data.scones.Mod);
            }


            milkBuyerPT.text = numToString(data.milkBuyer.Amount);
            milkBuyerButtonText.text = "$" + numToString(data.milkBuyer.Cost);
            steamerButtontext.text = "$" + numToString(data.steamer.Cost);
            steamerText.text = numToString(data.steamer.Amount);
            iceMakerPT.text = numToString(data.iceMaker.Amount);
            blenderPT.text = numToString(data.blender.Amount);
            pumpPT.text = numToString(data.pump.Amount);
            sconesNT.text = numToString(data.scones.Amount);

            pumpButtonText.text = "$" + numToString(data.pump.Cost);

            milkNT.text = numToString(data.milk.Amount);
            iceNT.text = numToString(data.ice.Amount);

            iceButtonText.text = "$" + numToString(data.iceMaker.Cost);

            blenderButtonText.text = "$" + numToString(data.blender.Cost);

            //coffees = (int)data.pots.Amount;
            // espressos = (int)data.espressoM.Amount;
            ovensText.text = numToString(data.ovens.Amount); ;
            ovensButtonText.text = "$ " + numToString(data.ovens.Cost);
          
            profit = (int)moneyMod - (int)data.beanBuyer.Amount * 10;
            if (profit >= 0)
            {
                moneyModText.text = "+" + numToString(profit);
            }
            else
            {
                moneyModText.text = numToString(profit);
            }
  

        }

       /* private String priceOf(Resource r)
        {
            String price;
            double cost = r.Cost;
            price = cost.ToString();
            if (cost > 1000)
            {
                cost = cost / 1000;
                price = cost.ToString() + "k";
            }
            if (cost > 1000000)
            {
                cost = cost / 1000;
                price = cost.ToString() + "M";
            }
            return price;
        }*/

        private void Disable(params TMP_Text[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i].enabled = false;
            }
        }
        private void Enable(params TMP_Text[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i].enabled = true;
            }
        }

        private void updatePpg()
        {
            ppg += (rnd.NextDouble() - 0.5) / 5;
        }

        private void revealText()
        {
            //enable espresso
            if (data.pots.Amount == 20)
            {
                Enable(EssMachN, espressoText, espressoButtonText, espressoN, ePriceText);
                espressoButton.SetActive(true);
            }
            //eanable store
            if ((data.pots.Amount + data.espressoM.Amount) == 5)
            {
                Enable(storeN, storesButtonText, storeText);
                storeButton.SetActive(true);
            }

            //enables bean buyer
            //when stores = 3
            if (data.stores.Amount > 2)
            {
                Enable(beanbuyerText, beanBuyN, bbuyerButtonText);
                beanBuyerButton.SetActive(true);
            }

            //enable latte and milk
            if (data.stores.Amount > 2 && data.espressoM.Amount > 4)
            {
                Enable(milkN, latteN, lPriceText, milkCount, milkModText);
                Enable(milkBuyN, milkBuyerPT, milkBuyerButtonText);
                milkBuyerButton.SetActive(true);

            }


            //enables steamer
            if (data.milk.Amount > 25)
            {
                Enable(steamerN, steamerText, steamerButtontext);
                steamerButton.SetActive(true);
            }
            //enables ice maker
            if (latteSold > 100)
            {
                Enable(iceMakerN, iceN, iceButtonText, iceCountText, iceMakerPT, iceNT, iceModText);
                iceMakerButton.SetActive(true);
            }


            //enables blender and frappe
            if (data.stores.Amount > 6)
            {

                Enable(blenderN, blenderPT, frappeN, fPriceText);
                blenderButton.SetActive(true);
            }

            //enables oven and scones
            //when stores = 2
            if (data.stores.Amount > 1)
            {
                Enable(OvenN, ovensButtonText, ovensText, sconeN, sconesNT, sPriceText, pastryStock, pastryMod, pastryStockText);
                ovenButton.SetActive(true);
            }

            //enables pump
            if (data.stores.Amount > 10) {
                Enable(pumpN, pumpPT);
               pumpButton.SetActive(true);
            }



        }

        //called every 1s
        private void UpdateStats()
        {
            salesText.text = "Coffees: " + coffeeSold + " Espressos: " + espressoSold + " Lattes: " + latteSold +" Frappes: " + frappeSold + " Pastries: " + sconeSold;
            //  salesTextString = "Coffees: " + coffeeSold + " Espressos: " + espressoSold + " Lattes: " + latteSold + " Iced: " + icedSold + " Frappes: " + frappeSold + " Matchas: " + mochaSold + " Scones: " + sconeSold;
            //  boxTitleString = "Sales";
   
            /*  data.beans.Amount += data.beans.Mod;
              updateCitizens();
              updatePpg();
              data.money += (int)moneyMod;*/
            addSold();
            foreach (var stat in data.stats)
            {
                stat.Amount += stat.Mod;


            }
            buybeans(data.beanBuyer.Amount * 10);
            data.money += (int)moneyMod;
        }



        public void buyEquip(string input)
        {
            Resource eq = data.equip.Find(item => item.Name == input);
            if (data.money >= eq.Cost)
            {
                eq.Amount += 1;
                data.money -= eq.Cost;
                eq.Cost = (int)((double)eq.BaseCost * Math.Pow(1.15, eq.Amount));
            }
            if (eq.Name.Equals( "Store")) {
                rate = rate * 0.9f;
            }
            if (eq.Name.Equals("Pump"))
            {
               FPrice = FPrice * 1.25;
            }
        }



        private void addSold()
        {
            calcSold();
            coffeeSold += coffees;
            espressoSold += espressos;
            latteSold += lattes;
           // icedSold += iceds;
            frappeSold += frappes;
            mochaSold += mochas;
            sconeSold += scones;
            muffinSold += muffins;
            bagelSold += bagels;
            

            //data.beans.Mod = data.beanBuyer.Amount * 50;
            data.milk.Mod = data.milkBuyer.Amount * 1;
            data.ice.Mod = data.iceMaker.Amount;
            data.beans.Mod = (-1) * (coffees + (espressos + lattes + frappes) * 2);
            data.milk.Mod += (-1) * (lattes + frappes);
            data.ice.Mod += (-2) * (frappes);
            moneyMod = coffees * 2 + espressos * 3 + lattes * 5 + scones * 2 + frappes * FPrice;
            data.scones.Mod = data.ovens.Amount - scones;
        }

        private void calcSold()
        {
           
            coffees = 0;
            espressos = 0;
            lattes = 0;
            frappes = 0;
         //   iceds = 0;

            double tempBeans = data.beans.Amount + data.beanBuyer.Amount * 10;
            double tempMilk = data.milk.Amount + data.milkBuyer.Amount;


            //get coffees sold
            for (int i = 0; i < data.pots.Amount; i++)
            {
                if ((data.beans.Amount + data.beanBuyer.Amount * 10) > i)
                {
                    coffees++;
                    tempBeans--;
                }
            }


            //get espressos4
            double tempBeans2 = tempBeans;
            for (int i = 0; i < data.espressoM.Amount; i++)
            {
                if ((tempBeans -= 2) >= 0)
                {
                    espressos++;

                }
            }
            //get lattees
            for (int i = 0; i < data.steamer.Amount; i++)
            {
                if ((tempMilk -= 1) >= 0 && espressos-- >= 0)
                {

                    lattes++;

                }
            }
         
            double tempice = data.ice.Amount;

            //get frappes
            for (int i = 0; i < data.blender.Amount; i++)
            {
                if (espressos-- > 0 && tempMilk-- > 0 && (((tempice-= 2)+ data.iceMaker.Amount) > -1))
                {
                    frappes++;
                }
            }



            scones = (int)((coffees + espressos +lattes + frappes) / 5);
            if (scones > (data.scones.Amount+data.ovens.Amount))
            {
                scones = (int)(data.scones.Amount + data.ovens.Amount);
            }

        }
        string numToString(double num) {
         
            if (num >= 100000000)
                return (num / 1000000).ToString("#,0M");

            if (num >= 10000000)
                return (num / 1000000).ToString("0.00") + "M";

            if (num >= 100000)
                return (num / 1000).ToString("#,0K");

            if (num >= 10000)
                return (num / 1000).ToString("0.00") + "K";

            return num.ToString("#,0");


        }
        string numToString(int inum)
        {
            double num = (double)inum;
            if (num >= 100000000)
                return (num / 1000000).ToString("#,0M");

            if (num >= 10000000)
                return (num / 1000000).ToString("0.00") + "M";

            if (num >= 100000)
                return (num / 1000).ToString("#,0K");

            if (num >= 10000)
                return (num / 1000).ToString("0.00") + "K";

            return num.ToString("#,0");


        }
       

        public void buybeans(int num)
        {
            if (data.money >= ppg * (num / 10))
            {

                data.money -= (int)(ppg) * (num / 10);
                data.beans.Amount += num;
            }


        }

    }
}