﻿using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable] public class Trade_Transaction : UObject
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private byte mTradeState;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn mInitiator;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_Pawn mPartner;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private List<ServerTradeItem> mInitiatorItems = new List<ServerTradeItem>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private List<ServerTradeItem> mPartnerItems = new List<ServerTradeItem>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mInitiatorMoney;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mPartnerMoney;

        //public delegate<OnPerformedTransaction> @__OnPerformedTransaction__Delegate;

        public Trade_Transaction()
        {
        }

        [Serializable] public struct ServerTradeItem
        {
            public Game_Item Item;

            public int Amount;

            public int LocationSlot;
        }

        public enum EServerTradeState
        {
            STS_REQUESTING,

            STS_TRADING,

            STS_OFFERED,

            STS_FINALIZING,

            STS_DONE,
        }
    }
}
/*
function Game_Pawn sv_GetOtherTrader(Game_Pawn aPawn) {
if (aPawn != None) {                                                        
if (aPawn == mInitiator) {                                                
return mPartner;                                                        
} else {                                                                  
return mInitiator;                                                      
}
}
return None;                                                                
}
function bool sv_IsTransactionValid() {
if (mTradeState == 4) {                                                     
return False;                                                             
}
if (mInitiator == None || mPartner == None) {                               
return False;                                                             
}
if (mInitiator.IsDead() || mPartner.IsDead()) {                             
return False;                                                             
}
if (mInitiator.Trading == None || mPartner.Trading == None) {               
return False;                                                             
}
return True;                                                                
}
event sv_PerformedTransaction(int aErrorCode) {
sv_SetState(4);                                                             
OnPerformedTransaction(self,aErrorCode == 0);                               
}
native function sv_PerformTransaction();
native function bool sv_HasSufficientSpace(Game_Pawn aTrader);
function sv_ResetOffer(Game_Pawn aTrader) {
if (aTrader != None && mTradeState != 3
&& sv_IsTransactionValid()) { 
if (aTrader == mInitiator) {                                              
mInitiatorMoney = 0;                                                    
mInitiatorItems.Length = 0;                                             
} else {                                                                  
mPartnerMoney = 0;                                                      
mPartnerItems.Length = 0;                                               
}
sv_SetState(1);                                                           
}
}
function int sv_GetTradeMoney(Game_Pawn aTrader) {
if (aTrader == mInitiator) {                                                
return mInitiatorMoney;                                                   
} else {                                                                    
return mPartnerMoney;                                                     
}
}
function bool sv_SetTradeMoney(Game_Pawn aTrader,int aMoney) {
if (aTrader != None && mTradeState != 3
&& sv_IsTransactionValid()) { 
aMoney = Min(aMoney,aTrader.Character.GetMoney());                        
if (aTrader == mInitiator) {                                              
mInitiatorMoney = aMoney;                                               
} else {                                                                  
mPartnerMoney = aMoney;                                                 
}
sv_SetState(1);                                                           
return True;                                                              
}
return False;                                                               
}
private function RemoveItem(out array<ServerTradeItem> outItems,int aLocationSlot) {
local int i;
i = 0;                                                                      
while (i < outItems.Length) {                                               
if (outItems[i].LocationSlot == aLocationSlot) {                          
outItems.Remove(i,1);                                                   
goto jl004A;                                                            
}
++i;                                                                      
}
}
function bool sv_RemoveItem(Game_Pawn aTrader,int aLocationSlot) {
if (aLocationSlot >= 0 && aLocationSlot < 16
&& aTrader != None
&& mTradeState != 3
&& sv_IsTransactionValid()) {
if (aTrader == mInitiator) {                                              
RemoveItem(mInitiatorItems,aLocationSlot);                              
} else {                                                                  
RemoveItem(mPartnerItems,aLocationSlot);                                
}
sv_SetState(1);                                                           
return True;                                                              
}
return False;                                                               
}
function bool sv_SetTradeItem(Game_Pawn aTrader,Game_Item aItem,int aAmount,int aLocationSlot) {
local ServerTradeItem serverItem;
if (aTrader != None && mTradeState != 3
&& sv_IsTransactionValid()) { 
serverItem.Item = aItem;                                                  
serverItem.Amount = aAmount;                                              
serverItem.LocationSlot = aLocationSlot;                                  
if (aTrader == mInitiator) {                                              
RemoveItem(mInitiatorItems,aLocationSlot);                              
mInitiatorItems[mInitiatorItems.Length] = serverItem;                   
} else {                                                                  
RemoveItem(mPartnerItems,aLocationSlot);                                
mPartnerItems[mPartnerItems.Length] = serverItem;                       
}
sv_SetState(1);                                                           
return True;                                                              
}
return False;                                                               
}
function sv_SetState(byte aState) {
mTradeState = aState;                                                       
}
function byte sv_GetState() {
return mTradeState;                                                         
}
function sv_TraderDisconnected(Game_Pawn aTrader) {
if (aTrader == mInitiator) {                                                
mInitiator = None;                                                        
} else {                                                                    
if (aTrader == mPartner) {                                                
mPartner = None;                                                        
}
}
}
function sv_InitTransaction(Game_Pawn aInitiator,Game_Pawn aPartner) {
mInitiator = aInitiator;                                                    
mPartner = aPartner;                                                        
sv_SetState(0);                                                             
}
delegate OnPerformedTransaction(Trade_Transaction aTransaction,bool aSucces);
*/