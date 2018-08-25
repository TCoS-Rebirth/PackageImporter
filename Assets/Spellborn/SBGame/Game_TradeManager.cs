﻿using System;
using System.Collections.Generic;
using SBBase;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable] public class Game_TradeManager : Base_Component
    {
        private List<Trade_Transaction> mTransactions = new List<Trade_Transaction>();

        public Game_TradeManager()
        {
        }
    }
}
/*
function OnPerformedTransactionHandler(Trade_Transaction aTransaction,bool aSuccess) {
local byte Message;
if (aSuccess) {                                                             
Message = Class'Game_Trading'.16;                                         
} else {                                                                    
Message = Class'Game_Trading'.15;                                         
}
if (aTransaction.mInitiator != None
&& aTransaction.mInitiator.Trading != None) {
aTransaction.mInitiator.Trading.sv2cl_TradingMessage_CallStub(Message);   
}
if (aTransaction.mPartner != None
&& aTransaction.mPartner.Trading != None) {
aTransaction.mPartner.Trading.sv2cl_TradingMessage_CallStub(Message);     
}
EndTransaction(aTransaction);                                               
}
private final function CreateTransaction(Game_Pawn aInitiator,Game_Pawn aPartner) {
local Trade_Transaction newTransaction;
newTransaction = new Class'Trade_Transaction';                              
newTransaction.sv_InitTransaction(aInitiator,aPartner);                     
newTransaction.__OnPerformedTransaction__Delegate = OnPerformedTransactionHandler;
mTransactions[mTransactions.Length] = newTransaction;                       
}
private final native function EndTransaction(Trade_Transaction aTransaction);
private final native function Trade_Transaction GetTransaction(Game_Pawn aPawn);
function sv_AcceptOffer(Game_Pawn aTrader) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
if (Transaction.sv_IsTransactionValid()) {                                
if (!Transaction.sv_HasSufficientSpace(aTrader)) {                      
aTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.12);
} else {                                                                
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                 
switch (Transaction.sv_GetState()) {                                  
case Class'Trade_Transaction'.2 :                                   
if (!Transaction.sv_HasSufficientSpace(otherTrader)) {            
aTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.13);
otherTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.12);
Transaction.sv_SetState(Class'Trade_Transaction'.1);            
} else {                                                          
Transaction.mInitiator.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.14);
Transaction.mPartner.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.14);
Transaction.sv_PerformTransaction();                            
}
break;                                                            
case Class'Trade_Transaction'.1 :                                   
Transaction.sv_SetState(Class'Trade_Transaction'.2);              
otherTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.10);
break;                                                            
default:                                                            
}
}
}
}
}
function sv_CancelOffer(Game_Pawn aTrader) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
if (Transaction.sv_IsTransactionValid()
&& Transaction.sv_GetState() == Class'Trade_Transaction'.3) {
Transaction.sv_SetState(1);                                             
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                   
otherTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.11);
}
}
}
function sv_CancelTrade(Game_Pawn aTrader) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
if (Transaction.sv_IsTransactionValid()
&& Transaction.sv_GetState() != Class'Trade_Transaction'.3) {
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                   
otherTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.9);
EndTransaction(Transaction);                                            
}
}
}
function sv_ResetOffer(Game_Pawn aTrader) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
Transaction.sv_ResetOffer(aTrader);                                       
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                     
otherTrader.Trading.sv2cl_ResetPartnerOffer_CallStub();                   
}
}
function sv_SetTradeMoney(Game_Pawn aTrader,int aMoney) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
if (Transaction.sv_SetTradeMoney(aTrader,aMoney)) {                       
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                   
otherTrader.Trading.sv2cl_SetPartnerMoney_CallStub(Transaction.sv_GetTradeMoney(aTrader));
}
}
}
function sv_RemoveItem(Game_Pawn aTrader,int aLocationSlot) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
if (Transaction.sv_RemoveItem(aTrader,aLocationSlot)) {                   
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                   
otherTrader.Trading.sv2cl_RemovePartnerItem_CallStub(aLocationSlot);    
}
}
}
function sv_SetTradeItem(Game_Pawn aTrader,int aDBID,int aAmount,int aLocationSlot) {
local Game_Item Item;
local ReplicatedItem repItem;
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None) {                                                  
if (aDBID > 0) {                                                          
Item = aTrader.itemManager.GetItemByID(aDBID);                          
}
if (Item != None
&& Transaction.sv_SetTradeItem(aTrader,Item,aAmount,aLocationSlot)) {
repItem = Item.GetReplicated();                                         
repItem.StackSize = aAmount;                                            
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                   
otherTrader.Trading.sv2cl_SetPartnerItem_CallStub(repItem,aLocationSlot);
}
}
}
function sv_AcceptRequest(Game_Pawn aTrader) {
local Trade_Transaction Transaction;
Transaction = GetTransaction(aTrader);                                      
if (Transaction != None
&& Transaction.mPartner == aTrader) {         
if (Transaction.sv_IsTransactionValid()) {                                
Transaction.sv_SetState(Class'Trade_Transaction'.1);                    
Transaction.mInitiator.Trading.sv2cl_RequestAccepted_CallStub();        
Transaction.mPartner.Trading.sv2cl_RequestAccepted_CallStub();          
}
}
}
function sv_RejectRequest(Game_Pawn aPartner,byte aMessage) {
local Trade_Transaction Transaction;
Transaction = GetTransaction(aPartner);                                     
if (Transaction != None
&& Transaction.mPartner == aPartner) {        
if (Transaction.sv_IsTransactionValid()) {                                
Transaction.mInitiator.Trading.sv2cl_TradingMessage_CallStub(aMessage); 
}
EndTransaction(Transaction);                                              
}
}
function sv_CancelRequest(Game_Pawn aInitiator) {
local Trade_Transaction Transaction;
Transaction = GetTransaction(aInitiator);                                   
if (Transaction != None
&& Transaction.mInitiator == aInitiator) {    
if (Transaction.sv_IsTransactionValid()) {                                
Transaction.mPartner.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.6);
}
EndTransaction(Transaction);                                              
}
}
function sv_RequestTrade(Game_Pawn aInitiator,Game_Pawn aPartner) {
local Trade_Transaction initiatorTransaction;
local Trade_Transaction partnerTransaction;
if (aInitiator == None || aInitiator.Trading == None) {                     
return;                                                                   
}
if (aPartner == None || aPartner.Trading == None) {                         
aInitiator.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.3);  
return;                                                                   
}
if (aPartner.combatState != None
&& aPartner.combatState.CombatReady()
|| aPartner.CombatStats != None
&& aPartner.CombatStats.InCombat()) {
aInitiator.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.1);  
return;                                                                   
}
initiatorTransaction = GetTransaction(aInitiator);                          
partnerTransaction = GetTransaction(aPartner);                              
if (initiatorTransaction != None) {                                         
aInitiator.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.0);  
} else {                                                                    
if (partnerTransaction != None) {                                         
aInitiator.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.1);
} else {                                                                  
CreateTransaction(aInitiator,aPartner);                                 
aPartner.Trading.sv2cl_RequestTrade_CallStub(aInitiator);               
}
}
}
function sv_HandleDeath(Game_Pawn aTrader) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
if (aTrader != None) {                                                      
Transaction = GetTransaction(aTrader);                                    
if (Transaction != None) {                                                
if (Transaction.sv_GetState() != Class'Trade_Transaction'.3
&& Transaction.sv_GetState() != Class'Trade_Transaction'.4) {
otherTrader = Transaction.sv_GetOtherTrader(aTrader);                 
if (otherTrader != None && !otherTrader.IsDead()) {                   
otherTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.5);
}
EndTransaction(Transaction);                                          
}
}
}
}
function sv_OnLogout(Game_PlayerPawn aPawn) {
local Game_Pawn otherTrader;
local Trade_Transaction Transaction;
Transaction = GetTransaction(aPawn);                                        
if (Transaction != None) {                                                  
if (Transaction.sv_IsTransactionValid()
&& Transaction.sv_GetState() != Class'Trade_Transaction'.3) {
otherTrader = Transaction.sv_GetOtherTrader(aPawn);                     
otherTrader.Trading.sv2cl_TradingMessage_CallStub(Class'Game_Trading'.4);
EndTransaction(Transaction);                                            
} else {                                                                  
Transaction.sv_TraderDisconnected(aPawn);                               
}
}
}
*/