/******************************************************************************/
/* BLINKY.C: LED Flasher                                                      */
/******************************************************************************/
/* This file is part of the uVision/ARM development tools.                    */
/* Copyright (c) 2005-2006 Keil Software. All rights reserved.                */
/* This software may only be used under the terms of a valid, current,        */
/* end user licence from KEIL for a compatible version of KEIL software       */
/* development tools. Nothing else gives you the right to use this software.  */
/******************************************************************************/
                  
#include <stdio.h>
#include <LPC23xx.H>                    /* LPC23xx definitions                */
#include "LCD.h"                        /* Graphic LCD function prototypes    */

#define LED_CMD 0
#define TIME_CMD 1
#define RESET_CMD 2
#define ME_CMD 3
#define CALC_CMD 4
#define PIANO_CMD 5
#define HELP_CMD 6
#define NA_CMD 7

char cmd[6], tmp[6];
int len = 0;

/* Init */
void Init(void);

/* Init UART1 */
void UART1_Init(void);
int getkey(void);
int sendchar(int ch);

__irq void UART1_Handler(void);

void HelpFunction(void);
void MeFunction(void);

/* Util */
void delay(int cd);
void addCommand(int ch);
void print(char s[], int l);
int getCommand(void);





/* Function that initializes LEDs                                             */
void LED_Init(void) {
  PINSEL10 = 0;                         /* Disable ETM interface, enable LEDs */
  FIO2DIR  = 0x000000FF;                /* P2.0..7 defined as Outputs         */
  FIO2MASK = 0x00000000;
}

/* Function that turns on requested LED                                       */
void LED_On (unsigned int num) {
  FIO2SET = (1 << num);
}

/* Function that turns off requested LED                                      */
void LED_Off (unsigned int num) {
  FIO2CLR = (1 << num);
}

/* Function that outputs value to LEDs                                        */
void LED_Out(unsigned int value) {
  FIO2CLR = 0xFF;                       /* Turn off all LEDs                  */
  FIO2SET = (value & 0xFF);             /* Turn on requested LEDs             */
}

void UART1_Init (void) {
	PINSEL0 = 0x40000000;
	//PINSEL0 &= !(0x3 << 30);
	//PINSEL0 |= 0x1 << 30;

	PINSEL1 &= !(0x3 << 0);
	PINSEL1 |= 0x1 << 0;

	U1LCR = 0x83;
	U1DLL = 78;
	U1DLM = 0;
	U1LCR = 0x03;
 	U1IER = 1;
	// interrupt
	VICVectAddr7 = (unsigned long) UART1_Handler;
	VICVectCntl7 = 1;
	VICIntEnable |= (1 << 7);	
}

__irq void UART1_Handler() {
	int ch;
	ch = getkey();
	sendchar(ch);
	if (ch == 13) {
		sendchar(10);
		getCommand();
	}
	else {
		addCommand(ch);
	}

	EXTINT = 1;
	VICVectAddr = 0;
}

int getkey (void) {
	while (!(U1LSR & 0x01));

	return U1RBR;
}

int sendchar (int ch) {
	while (!(U1LSR & 0x20));

	return (U1THR = ch);
}

void delay (int cd) {
	int i;
	for (i = 0; i < cd*1000000; i++) ;
}

void Init(void) {
	VICIntEnable = 0;
}

void addCommand (int ch) {
	cmd[len++] = ch;
}

void print(char s[], int l) {
	int i;
	for (i = 0; i < l; i++) {
		sendchar(s[i]);
	}
	sendchar(10);
	sendchar(13);
}

int getCommand () {
	int i;
	// copy command to temp
	for (i = 0; i < 6; i++) {
		tmp[i] = cmd[i];
		cmd[i] = -1;
	}

	len = 0;

	// LED command
	if (tmp[0] == 'L' || tmp[0] == 'l') {
		return LED_CMD;
	}

	// HELP command
	if (tmp[0] == 'H' || tmp[0] == 'h') {
		HelpFunction();
		return HELP_CMD;
	}

	// PIANO command
	if (tmp[0] == 'P' || tmp[0] == 'p') {
		return PIANO_CMD;
	}

	// ME command
	if (tmp[0] == 'M' || tmp[0] == 'm') {
		MeFunction();
		return ME_CMD;
	}

	return NA_CMD;
}

void HelpFunction(void) {
	char help[] = "help";
	print(help, 4);
}

void MeFunction (void) {
	char me[] = "Nguyen Hoang Vu";
	print(me, 15);
}

int main (void) {

	Init();

	LED_Init();
	UART1_Init();

	LED_Out(0x00);

	delay(1);
	while (1) {
		
	}
}
