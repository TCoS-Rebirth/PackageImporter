using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable]
    public class Game_Trading: Base_Component
    {
        public const int MAX_TRADE_ITEMS = 16;

        private byte mTradeState;

        private int mMoney;

        private string mPartnerName = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private Shop_Base mShop;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private byte mShopOption;

        [Serializable]
        public struct PaintItem
        {
            public int DBID;

            public byte Color1;

            public byte Color2;
        }

        public enum EItemForgeError
        {
            IFE_InternalError,

            IFE_WrongShopType,

            IFE_NoneForgableItem,

            IFE_SlotInvalid,

            IFE_NotAToken,

            IFE_IncompatibleSlotType,

            IFE_LevelTooLow,

            IFE_TokenRankTooHigh,

            IFE_NotEnoughMoney,

            IFE_NoTokensToRemove,

            IFE_NotEnoughInventorySpace,
        }

        public enum ETradingMessages
        {
            TM_REQ_BUSY_SELF,

            TM_REQ_BUSY_PARTNER,

            TM_REQ_IGNORED_ME,

            TM_REQ_FAILED,

            TM_DISCONNECT,

            TM_DIED,

            TM_REQ_CANCEL,

            TM_REQ_REJECT,

            TM_REQ_ACCEPTED,

            TM_TRADE_CANCELED,

            TM_OFFER_ACCEPTED,

            TM_OFFER_CANCELED,

            TM_INSUFFICIENT_SPACE,

            TM_PARTNER_INSUFFICIENT_SPACE,

            TM_FINALIZING,

            TM_FAILED,

            TM_DONE,
        }

        public enum EClientTradeStates
        {
            CTS_NONE,

            CTS_REQUESTING,

            CTS_RESPONSE,

            CTS_ACCEPTING,

            CTS_TRADING,

            CTS_OFFERED,

            CTS_FINALIZING,
        }

        public void cl_HandleDeath()
        {
            Debug.LogWarning("Game_Trading.cl_HandleDeath not implemented");
            //if (mTradeState != 0) {                                                     
            //    cl_ShowTradeRequestWindow(False);                                         
            //    cl_ShowTradeWindow(False);                                                
            //    cl_ReInit();                                                              
            //    cl2sv_HandleDeath_CallStub();                                             
            //} else {                                                                    
            //if (mShop != None) {                                                      
            //    Game_PlayerController(Outer.Controller).GUI.HideShop();                 
            //}
            //}
        }
    }
}
/*
protected native function sv2cl_RemoveSigilsCompleted_CallStub();
event sv2cl_RemoveSigilsCompleted(bool aSuccess,byte aErrorMessage) {
OnRemoveSigilsComplete(aSuccess,aErrorMessage);                             
}
event sv_RemoveSigilsCompleted(int aErrorCode) {
sv2cl_RemoveSigilsCompleted_CallStub(aErrorCode == 0,0);                    
}
protected native function cl2sv_RemoveSigils_CallStub();
native event cl2sv_RemoveSigils(int aDBID);
function cl_RemoveSigils(Game_Item aItem) {
cl2sv_RemoveSigils_CallStub(aItem.DBID);                                    
}
delegate OnRemoveSigilsComplete(bool aSuccess,byte aErrorMessage);
protected native function sv2cl_ForgeSigilCompleted_CallStub();
event sv2cl_ForgeSigilCompleted(bool aSuccess,byte aErrorMessage) {
OnForgeSigilComplete(aSuccess,aErrorMessage);                               
}
event sv_ForgeSigilCompleted(int aErrorCode) {
sv2cl_ForgeSigilCompleted_CallStub(aErrorCode == 0,0);                      
}
protected native function cl2sv_ForgeSigil_CallStub();
native event cl2sv_ForgeSigil(int aTokenDBID,int aTargetLocationSlot,int aTargetLocationID);
function cl_ForgeSigil(Game_Item aTokenItem,int aTargetLocationSlot,int aTargetLocationID) {
cl2sv_ForgeSigil_CallStub(aTokenItem.DBID,aTargetLocationSlot,aTargetLocationID);
}
delegate OnForgeSigilComplete(bool aSuccess,byte aErrorMessage);
function bool CanCreateRecipe(Game_Item aItem,export out editinline Item_Type aOutRecipeType,out int aCost) {
local export editinline IC_Broken brokenComponent;
if (mShopOption != 27) {                                                    
return False;                                                             
}
if (aItem == None || aItem.Type.ItemType != 38) {                           
return False;                                                             
}
brokenComponent = IC_Broken(aItem.Type.GetComponentByClass(Class'IC_Broken'));
if (brokenComponent == None || brokenComponent.Recipe == None) {            
return False;                                                             
}
aCost = brokenComponent.GetRecipePrice();                                   
if (aCost > Outer.Character.GetMoney()) {                                   
return False;                                                             
}
aOutRecipeType = brokenComponent.Recipe;                                    
return True;                                                                
}
protected native function sv2cl_CreateRecipeCompleted_CallStub();
event sv2cl_CreateRecipeCompleted(bool aSuccess) {
OnCreateRecipeComplete(aSuccess);                                           
}
function sv_CreateRecipeCompleted(int aErrorCode) {
sv2cl_CreateRecipeCompleted_CallStub(aErrorCode == 0);                      
}
native function bool sv_CreateRecipe(Game_Item aItem,export editinline Item_Type aRecipeType,int aCost,SBDBAsyncCallback aCallback);
protected native function cl2sv_CreateRecipe_CallStub();
event cl2sv_CreateRecipe(int aDBID) {
local Game_Item Item;
local export editinline Item_Type recipeType;
local int cost;
local SBDBAsyncCallback callback;
Item = Game_PlayerItemManager(Outer.itemManager).GetItemByID(aDBID);        
if (CanCreateRecipe(Item,recipeType,cost) == False) {                       
return;                                                                   
}
callback.ObjectName = static.GetFName();                                    
callback.funcName = name("sv_CreateRecipeCompleted");                       
callback.UserData = 0;                                                      
if (!sv_CreateRecipe(Item,recipeType,cost,callback)) {                      
sv2cl_CreateRecipeCompleted_CallStub(False);                              
return;                                                                   
}
}
function cl_CreateRecipe(Game_Item aItem) {
cl2sv_CreateRecipe_CallStub(aItem.DBID);                                    
}
delegate OnCreateRecipeComplete(bool aSuccess);
function bool CanAffordRecipe(export editinline IC_Recipe aRecipeComponent) {
return aRecipeComponent != None
&& Outer.Character.GetMoney() >= aRecipeComponent.GetCraftPrice();
}
function bool HasRecipeResources(export editinline IC_Recipe aRecipeComponent) {
local int i;
local int avaiableAmount;
if (aRecipeComponent != None) {                                             
i = 0;                                                                    
while (i < aRecipeComponent.Components.Length) {                          
avaiableAmount = Outer.itemManager.CountItems(aRecipeComponent.Components[i].Item);
if (avaiableAmount < aRecipeComponent.Components[i].Quantity) {         
return False;                                                         
}
++i;                                                                    
}
return True;                                                              
}
return False;                                                               
}
function bool IsValidRecipeItem(Game_Item aItem,export out editinline IC_Recipe aOutRecipeComponent) {
if (mShop != None) {                                                        
return mShop.IsValidRecipeItem(aItem,mShopOption,aOutRecipeComponent);    
}
return False;                                                               
}
protected native function sv2cl_CraftRecipeCompleted_CallStub();
event sv2cl_CraftRecipeCompleted(bool aSuccess) {
OnCraftRecipeComplete(aSuccess);                                            
}
function sv_CraftRecipeCompleted(int aErrorCode) {
sv2cl_CraftRecipeCompleted_CallStub(aErrorCode == 0);                       
}
native function bool sv_CraftRecipe(Game_Item aItem,export editinline IC_Recipe aRecipeComponent,SBDBAsyncCallback aCallback);
protected native function cl2sv_CraftRecipe_CallStub();
event cl2sv_CraftRecipe(int aDBID) {
local Game_Item Item;
local export editinline IC_Recipe recipeComp;
local SBDBAsyncCallback callback;
callback.ObjectName = static.GetFName();                                    
callback.funcName = name("sv_CraftRecipeCompleted");                        
callback.UserData = 0;                                                      
Item = Game_PlayerItemManager(Outer.itemManager).GetItemByID(aDBID);        
if (!IsValidRecipeItem(Item,recipeComp)) {                                  
return;                                                                   
}
if (!CanAffordRecipe(recipeComp)
|| !HasRecipeResources(recipeComp)) {
return;                                                                   
}
if (!sv_CraftRecipe(Item,recipeComp,callback)) {                            
sv2cl_CraftRecipeCompleted_CallStub(False);                               
return;                                                                   
}
}
function cl_CraftRecipe(Game_Item aItem) {
cl2sv_CraftRecipe_CallStub(aItem.DBID);                                     
}
delegate OnCraftRecipeComplete(bool aSuccess);
event int GetPaintCost(Game_Item aItem) {
local export editinline IC_Appearance appearanceComp;
appearanceComp = IC_Appearance(aItem.Type.GetComponentByClass(Class'IC_Appearance'));
if (appearanceComp == None
|| appearanceComp.Appearance == None) {    
return -1;                                                                
}
return appearanceComp.DyePrice;                                             
}
event bool CanPaintItem(Game_Item aItem) {
if (aItem != None && aItem.Type != None) {                                  
switch (aItem.Type.ItemType) {                                            
case Class'Item_Type'.16 :                                              
case Class'Item_Type'.17 :                                              
case Class'Item_Type'.18 :                                              
case Class'Item_Type'.19 :                                              
case Class'Item_Type'.20 :                                              
case Class'Item_Type'.21 :                                              
case Class'Item_Type'.22 :                                              
case Class'Item_Type'.23 :                                              
case Class'Item_Type'.24 :                                              
case Class'Item_Type'.34 :                                              
case Class'Item_Type'.35 :                                              
case Class'Item_Type'.25 :                                              
case Class'Item_Type'.26 :                                              
case Class'Item_Type'.27 :                                              
case Class'Item_Type'.28 :                                              
case Class'Item_Type'.29 :                                              
return True;                                                          
break;                                                                
default:                                                                
break;                                                                
}
}
return False;                                                               
}
protected native function sv2cl_PaintCompleted_CallStub();
event sv2cl_PaintCompleted(bool aSuccess) {
OnPaintComplete(aSuccess);                                                  
}
function sv_PaintCompleted(int aErrorCode) {
sv2cl_PaintCompleted_CallStub(aErrorCode == 0);                             
}
final native function bool sv_PaintItems(array<PaintItem> aRepItems,int aCost,SBDBAsyncCallback aCallback);
protected native function cl2sv_PaintItems_CallStub();
event cl2sv_PaintItems(array<PaintItem> aPaintItems) {
local SBDBAsyncCallback callback;
local Game_Item Item;
local export editinline Game_PlayerItemManager itemManager;
local int totalCost;
local int i;
local int tempCost;
itemManager = Game_PlayerItemManager(Outer.itemManager);                    
if (itemManager == None) {                                                  
sv2cl_PaintCompleted_CallStub(False);                                     
return;                                                                   
}
totalCost = 0;                                                              
i = 0;                                                                      
while (i < aPaintItems.Length) {                                            
Item = itemManager.GetItemByID(aPaintItems[i].DBID);                      
if (Item == None || !CanPaintItem(Item)) {                                
sv2cl_PaintCompleted_CallStub(False);                                   
return;                                                                 
}
tempCost = GetPaintCost(Item);                                            
if (tempCost == -1) {                                                     
sv2cl_PaintCompleted_CallStub(False);                                   
return;                                                                 
}
totalCost += tempCost;                                                    
++i;                                                                      
}
callback.ObjectName = static.GetFName();                                    
callback.funcName = name("sv_PaintCompleted");                              
callback.UserData = 0;                                                      
if (sv_PaintItems(aPaintItems,totalCost,callback)) {                        
return;                                                                   
}
sv2cl_PaintCompleted_CallStub(False);                                       
}
function cl_PaintItems(array<PaintItem> aPaintItems) {
if (aPaintItems.Length > 0) {                                               
cl2sv_PaintItems_CallStub(aPaintItems);                                   
}
}
delegate OnPaintComplete(bool aSuccess);
event bool CanBuyItem(export editinline Item_Type aItemType,int aAmount) {
local int playerMoney;
if (Outer != None && Outer.Character != None) {                             
playerMoney = Game_PlayerCharacter(Outer.Character).GetMoney();           
}
return aItemType != None && aAmount > 0
&& playerMoney >= aItemType.GetBuyPrice() * aAmount
&& mShop != None
&& mShop.HasItemInStock(aItemType.GetResourceId(),aAmount);
}
protected native function sv2cl_BuyCompleted_CallStub();
event sv2cl_BuyCompleted(bool aSuccess) {
OnBuyComplete(aSuccess);                                                    
}
function sv_BuyCompleted(int aErrorCode) {
sv2cl_BuyCompleted_CallStub(aErrorCode == 0);                               
}
native function bool sv_BuyItem(export editinline Item_Type aItem,int aAmount,int aTargetLocationSlot,SBDBAsyncCallback aCallback);
protected native function cl2sv_BuyItem_CallStub();
event cl2sv_BuyItem(int aItemTypeID,int aAmount,int aTargetLocationSlot) {
local SBDBAsyncCallback callback;
local export editinline Item_Type ItemType;
callback.ObjectName = static.GetFName();                                    
callback.funcName = name("sv_BuyCompleted");                                
callback.UserData = 0;                                                      
if (aAmount <= 0) {                                                         
aAmount = 1;                                                              
} else {                                                                    
if (aAmount > 10) {                                                       
aAmount = 10;                                                           
}
}
ItemType = Item_Type(Class'SBDBSync'.GetResourceObject(aItemTypeID));       
if (CanBuyItem(ItemType,aAmount)
&& sv_BuyItem(ItemType,aAmount,aTargetLocationSlot,callback)) {
return;                                                                   
}
sv2cl_BuyCompleted_CallStub(False);                                         
}
function cl_BuyItem(Game_Item aItem,int aAmount,int aTargetLocationSlot) {
cl2sv_BuyItem_CallStub(aItem.Type.GetResourceId(),aAmount,aTargetLocationSlot);
}
delegate OnBuyComplete(bool aSuccess);
event bool CanSellItem(Game_Item aItem) {
if (mShopOption < 20 || mShopOption > 26) {                                 
return False;                                                             
}
return aItem != None && aItem.Type != None
&& aItem.Type.Sellable
&& mShop != None
&& mShop.CanBuyItem(aItem.Type.ItemType);
}
protected native function sv2cl_SellCompleted_CallStub();
event sv2cl_SellCompleted(bool aSuccess) {
OnSellComplete(aSuccess);                                                   
}
function sv_SellCompleted(int aErrorCode) {
sv2cl_SellCompleted_CallStub(aErrorCode == 0);                              
}
native function bool sv_SellItems(array<Game_Item> aItem,SBDBAsyncCallback aCallback);
protected native function cl2sv_SellItems_CallStub();
event cl2sv_SellItems(array<int> aItemIDs) {
local int i;
local Game_Item Item;
local array<Game_Item> Items;
local SBDBAsyncCallback callback;
if (aItemIDs.Length > 0) {                                                  
callback.ObjectName = static.GetFName();                                  
callback.funcName = name("sv_SellCompleted");                             
callback.UserData = 0;                                                    
i = 0;                                                                    
while (i < aItemIDs.Length) {                                             
Item = Game_PlayerItemManager(Outer.itemManager).GetItemByID(aItemIDs[i]);
if (Item == None || !CanSellItem(Item)) {                               
goto jl00C9;                                                          
}
Items[Items.Length] = Item;                                             
++i;                                                                    
}
if (Items.Length == aItemIDs.Length) {                                    
if (sv_SellItems(Items,callback)) {                                     
return;                                                               
}
}
}
sv2cl_SellCompleted_CallStub(False);                                        
}
function cl_SellItems(array<int> aItemIDs) {
if (aItemIDs.Length == 0) {                                                 
OnSellComplete(False);                                                    
return;                                                                   
}
cl2sv_SellItems_CallStub(aItemIDs);                                         
}
delegate OnSellComplete(bool aSuccess);
function array<Game_Item> cl_GetShopStock() {
return mShop.GetItems();                                                    
}
function bool IsShopping() {
return mShop != None;                                                       
}
function byte cl_GetShopOption() {
return mShopOption;                                                         
}
function Shop_Base cl_GetShop() {
return mShop;                                                               
}
function ResetShop() {
mShop = None;                                                               
mShopOption = 36;                                                           
}
protected native function cl2sv_ExitShop_CallStub();
event cl2sv_ExitShop() {
ResetShop();                                                                
}
function cl_ExitShop() {
ResetShop();                                                                
cl2sv_ExitShop_CallStub();                                                  
}
protected native function sv2cl_EnterShop_CallStub();
event sv2cl_EnterShop() {
if (mShop != None) {                                                        
Game_PlayerController(Outer.Controller).GUI.ShowShop(mShop,mShopOption);  
} else {                                                                    
ResetShop();                                                              
}
}
function sv_EnterShop(Shop_Base aShopInfo,byte aOption) {
mShop = aShopInfo;                                                          
mShopOption = aOption;                                                      
sv2cl_EnterShop_CallStub();                                                 
}
function cl_SetShop(Shop_Base aShopInfo,byte aOption) {
mShop = aShopInfo;                                                          
mShopOption = aOption;                                                      
}
protected native function cl2sv_AcceptOffer_CallStub();
private event cl2sv_AcceptOffer() {
sv_GetTradeManager().sv_AcceptOffer(Outer);                                 
}
function cl_AcceptOffer() {
mTradeState = 5;                                                            
cl2sv_AcceptOffer_CallStub();                                               
}
protected native function cl2sv_CancelTrade_CallStub();
private event cl2sv_CancelTrade() {
sv_GetTradeManager().sv_CancelTrade(Outer);                                 
}
protected native function cl2sv_CancelOffer_CallStub();
event cl2sv_CancelOffer() {
sv_GetTradeManager().sv_CancelOffer(Outer);                                 
}
function cl_CancelTrade() {
if (mTradeState == 5) {                                                     
mTradeState = 4;                                                          
cl2sv_CancelOffer_CallStub();                                             
} else {                                                                    
cl_ReInit();                                                              
cl_ShowTradeWindow(False);                                                
cl2sv_CancelTrade_CallStub();                                             
}
}
protected native function sv2cl_ResetPartnerOffer_CallStub();
event sv2cl_ResetPartnerOffer() {
OnResetPartnerOffer();                                                      
}
protected native function cl2sv_ResetOffer_CallStub();
private event cl2sv_ResetOffer() {
sv_GetTradeManager().sv_ResetOffer(Outer);                                  
}
function cl_ResetOffer() {
mMoney = 0;                                                                 
cl2sv_ResetOffer_CallStub();                                                
}
protected native function sv2cl_SetPartnerMoney_CallStub();
event sv2cl_SetPartnerMoney(int aMoney) {
OnSetPartnerMoney(aMoney);                                                  
}
protected native function cl2sv_SetTradeMoney_CallStub();
private event cl2sv_SetTradeMoney(int aMoney) {
sv_GetTradeManager().sv_SetTradeMoney(Outer,aMoney);                        
}
function cl_SetTradeMoney(int aMoney) {
if (aMoney > 0) {                                                           
mMoney = aMoney;                                                          
} else {                                                                    
mMoney = 0;                                                               
}
cl2sv_SetTradeMoney_CallStub(mMoney);                                       
}
protected native function sv2cl_RemovePartnerItem_CallStub();
event sv2cl_RemovePartnerItem(int aLocationSlot) {
OnRemovePartnerItem(aLocationSlot);                                         
}
protected native function cl2sv_RemoveItem_CallStub();
private event cl2sv_RemoveItem(int aLocationSlot) {
sv_GetTradeManager().sv_RemoveItem(Outer,aLocationSlot);                    
}
function cl_RemoveItem(int aLocationSlot) {
if (aLocationSlot >= 0 && aLocationSlot < 16) {                             
cl2sv_RemoveItem_CallStub(aLocationSlot);                                 
}
}
protected native function sv2cl_SetPartnerItem_CallStub();
event sv2cl_SetPartnerItem(ReplicatedItem aItem,int aLocationSlot) {
local export editinline Item_Type ItemType;
local Game_Item Item;
ItemType = Item_Type(Class'SBDBSync'.GetResourceObject(aItem.ItemTypeID));  
Item = new Class'Game_Item';                                                
Item.Type = ItemType;                                                       
Item.Color1 = aItem.Color1;                                                 
Item.Color2 = aItem.Color2;                                                 
Item.StackSize = aItem.StackSize;                                           
OnSetPartnerItem(Item,aLocationSlot);                                       
}
protected native function cl2sv_SetTradeItem_CallStub();
private event cl2sv_SetTradeItem(int aDBID,int aAmount,int aLocationSlot) {
sv_GetTradeManager().sv_SetTradeItem(Outer,aDBID,aAmount,aLocationSlot);    
}
function cl_SetTradeItem(Game_Item aItem,int aAmount,int aLocationSlot) {
if (aItem != None) {                                                        
cl2sv_SetTradeItem_CallStub(aItem.DBID,aAmount,aLocationSlot);            
}
}
protected native function sv2cl_RequestAccepted_CallStub();
event sv2cl_RequestAccepted() {
mTradeState = 4;                                                            
cl_ShowTradeRequestWindow(False);                                           
cl_ShowTradeWindow(True);                                                   
}
protected native function cl2sv_AcceptRequest_CallStub();
private event cl2sv_AcceptRequest() {
sv_GetTradeManager().sv_AcceptRequest(Outer);                               
}
function cl_AcceptTradeRequest() {
mTradeState = 3;                                                            
cl_ShowTradeRequestWindow(False);                                           
cl_SendTradeStatusMessage(8);                                               
cl2sv_AcceptRequest_CallStub();                                             
}
protected native function cl2sv_RejectRequest_CallStub();
private event cl2sv_RejectRequest(byte aMessage) {
sv_GetTradeManager().sv_RejectRequest(Outer,aMessage);                      
}
function cl_RejectTradeRequest(byte aMessage) {
cl_ReInit();                                                                
cl_ShowTradeRequestWindow(False);                                           
cl2sv_RejectRequest_CallStub(aMessage);                                     
}
protected native function cl2sv_CancelRequest_CallStub();
private event cl2sv_CancelRequest() {
sv_GetTradeManager().sv_CancelRequest(Outer);                               
}
function cl_CancelTradeRequest() {
cl_ReInit();                                                                
cl_ShowTradeRequestWindow(False);                                           
cl2sv_CancelRequest_CallStub();                                             
}
protected native function sv2cl_RequestTrade_CallStub();
event sv2cl_RequestTrade(Game_Pawn aInitiator) {
if (Game_PlayerController(Outer.Controller).GroupingFriends.IsIgnoring(aInitiator)) {
cl_RejectTradeRequest(2);                                                 
return;                                                                   
}
mPartnerName = aInitiator.GetCharacterName();                               
mTradeState = 2;                                                            
cl_ShowTradeRequestWindow(True);                                            
}
protected native function cl2sv_RequestTrade_CallStub();
event cl2sv_RequestTrade(Game_Pawn aPartner) {
sv_GetTradeManager().sv_RequestTrade(Outer,aPartner);                       
}
function cl_RequestTrade(Game_Pawn aPartner) {
if (aPartner != None) {                                                     
mPartnerName = aPartner.GetCharacterName();                               
mTradeState = 1;                                                          
cl_ShowTradeRequestWindow(True);                                          
cl2sv_RequestTrade_CallStub(aPartner);                                    
}
}
private function cl_ReInit() {
mPartnerName = "";                                                          
mTradeState = 0;                                                            
mMoney = 0;                                                                 
}
protected native function sv2cl_TradingMessage_CallStub();
event sv2cl_TradingMessage(byte aMessage) {
cl_SendTradeStatusMessage(aMessage);                                        
switch (aMessage) {                                                         
case 4 :                                                                  
case 5 :                                                                  
cl_ReInit();                                                            
cl_ShowTradeRequestWindow(False);                                       
cl_ShowTradeWindow(False);                                              
break;                                                                  
case 0 :                                                                  
case 1 :                                                                  
case 2 :                                                                  
case 3 :                                                                  
case 6 :                                                                  
case 7 :                                                                  
cl_ReInit();                                                            
cl_ShowTradeRequestWindow(False);                                       
break;                                                                  
case 8 :                                                                  
cl_ShowTradeRequestWindow(False);                                       
break;                                                                  
case 9 :                                                                  
cl_ReInit();                                                            
cl_ShowTradeWindow(False);                                              
break;                                                                  
case 12 :                                                                 
mTradeState = 4;                                                        
OnAcceptCancelled();                                                    
break;                                                                  
case 13 :                                                                 
OnSetPartnerOffered(True);                                              
OnAcceptCancelled();                                                    
break;                                                                  
case 10 :                                                                 
OnSetPartnerOffered(True);                                              
break;                                                                  
case 11 :                                                                 
OnSetPartnerOffered(False);                                             
break;                                                                  
case 14 :                                                                 
mTradeState = 6;                                                        
cl_ShowTradeWindow(False);                                              
break;                                                                  
case 15 :                                                                 
case 16 :                                                                 
cl_ReInit();                                                            
break;                                                                  
default:                                                                  
}
}
private function cl_SendTradeStatusMessage(byte aMessage) {
local Game_Desktop desktop;
local string partner;
local string Message;
desktop = Game_Desktop(Game_PlayerController(Outer.Controller).Player.GUIDesktop);
partner = cl_GetPartnerName();                                              
switch (aMessage) {                                                         
case 4 :                                                                  
Message = Class'StringReferences'.default.PARTNERNAME_has_left_the_area.Text;
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 5 :                                                                  
Message = Class'StringReferences'.default.PARTNERNAME_has_died.Text;    
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 0 :                                                                  
desktop.AddScreenMessage(Class'StringReferences'.default.The_server_is_still_busy_with_your_previous_trade.Text);
break;                                                                  
case 1 :                                                                  
Message = Class'StringReferences'.default.PARTNERNAME_is_busy.Text;     
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 2 :                                                                  
Message = Class'StringReferences'.default.PLAYERNAME_ignored_you_.Text; 
static.ReplaceText(Message,"[PLAYERNAME]",partner);                     
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 3 :                                                                  
desktop.AddScreenMessage(Class'StringReferences'.default.Internal_trade_error.Text);
break;                                                                  
case 6 :                                                                  
Message = Class'StringReferences'.default.PARTNERNAME_has_cancelled_the_trade_invitation.Text;
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 7 :                                                                  
Message = Class'StringReferences'.default.PARTNERNAME_has_rejected_your_trade_invitation.Text;
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 8 :                                                                  
break;                                                                  
case 9 :                                                                  
Message = Class'StringReferences'.default.PARTNERNAME_cancelled_the_trade.Text;
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 12 :                                                                 
desktop.AddScreenMessage(Class'StringReferences'.default.Not_enough_space_in_your_inventory.Text);
break;                                                                  
case 13 :                                                                 
Message = Class'StringReferences'.default.PARTNERNAME_not_enough_space_in_inventory.Text;
static.ReplaceText(Message,"[PARTNERNAME]",partner);                    
desktop.AddScreenMessage(Message);                                      
break;                                                                  
case 14 :                                                                 
break;                                                                  
case 15 :                                                                 
desktop.AddScreenMessage(Class'StringReferences'.default.Trade_failed.Text);
break;                                                                  
case 16 :                                                                 
desktop.AddScreenMessage(Class'StringReferences'.default.Trade_completed.Text);
break;                                                                  
default:                                                                  
}
}
private function cl_ShowTradeWindow(bool aShow) {
if (aShow) {                                                                
Game_PlayerController(Outer.Controller).GUI.ShowTrade();                  
} else {                                                                    
Game_PlayerController(Outer.Controller).GUI.HideTrade();                  
}
}
private function cl_ShowTradeRequestWindow(bool aShow) {
if (aShow) {                                                                
Game_PlayerController(Outer.Controller).GUI.ShowTradeRequest();           
} else {                                                                    
Game_PlayerController(Outer.Controller).GUI.HideTradeRequest();           
}
}
function byte cl_GetTradeState() {
return mTradeState;                                                         
}
function string cl_GetPartnerName() {
return mPartnerName;                                                        
}
event bool cl_IsTrading() {
return mTradeState != 0;                                                    
}
protected native function cl2sv_HandleDeath_CallStub();
event cl2sv_HandleDeath() {
sv_GetTradeManager().sv_HandleDeath(Outer);                                 
}
private function Game_TradeManager sv_GetTradeManager() {
local Game_GameInfo GameInfo;
if (Outer != None && Outer.Level != None) {                                 
GameInfo = Game_GameInfo(Outer.GetGameInfo());                            
if (GameInfo != None && GameInfo.mTradeManager != None) {                 
return GameInfo.mTradeManager;                                          
}
}
return None;                                                                
}
delegate OnAcceptCancelled();
delegate OnSetPartnerOffered(bool aOffered);
delegate OnResetPartnerOffer();
delegate OnSetPartnerMoney(int aMoney);
delegate OnRemovePartnerItem(int aLocationSlot);
delegate OnSetPartnerItem(Game_Item aItem,int aLocationSlot);
*/
