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

#define CMD		1
#define NA_CMD	0
#define LED		2
#define TIME	3
#define CALC	4
#define RESET	5
#define HELP	6
#define ME		7
#define PIANO	8

#define MAX_LEN		20
#define PCLK 15000000

char __cmd[10][20];
int __ind;
int __len;
int mode = NA_CMD;


typedef struct DATETIME {
	int day, mon, year;
	int hour, min, sec;

} DateTime;


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

///////////////////////////////////////////////
/* Function that initializes LEDs                                             */
void LED_Init(void) {
  PINSEL10 = 0;                         /* Disable ETM interface, enable LEDs */
  FIO2DIR  = 0x000000FF;                /* P2.0..7 defined as Outputs         */
  FIO2MASK = 0x00000000;
}

/* Init UART1 */
void UART1_Init(void);
__irq void UART1_Handler(void);

int getkey(void);
int sendchar(int ch);



void HelpFunction(void);
void MeFunction(void);

/* Util */
void addCommand(int ch);
void print(char *s);

void printCommand(void);
void nl(void);

//------------------------------------------------------
void parseCommand(char* cmd, char* op, char* params);
void getCommand(void);
void getCommand2(void);

void ptrLEDFunction(int n, void (*f)(int n));
void parseLED(char* cmd);

int add(int n1, int n2);
int sub(int n1, int n2);
int mul(int n1, int n2);
int div(int n1, int n2);
int mod(int n1, int n2);
int ptrCalcFunction(int n1, int n2, int (*calc)(int n1, int n2));

void parseTIME(char *cmd);
void parseCALC(char *cmd);
void parseCALCCommand(char *cmd, char *op, int *n1, int* n2);

DateTime setDateTimeByString(char *params);
DateTime setDateTime(int day, int mon, int year, int hour, int min, int sec);
int atoi(char n);
//------------------------------------------------------

void ptrLEDFunction(int n, void (*f)(int n)) {
    f(n);
}

void parseCommand(char* cmd, char* op, char* params) {
    int i;
    int pLen = 0;

    for (i = 0; i < strlen(cmd); i++) {
        if (cmd[i] == ' ') {
            op[i] = '\0';
            i++;
            break;
        }
        op[i] = cmd[i];
    }
    op[i+1] = '\0';

    for (/*continue with i*/; i < strlen(cmd); i++) {
        params[pLen++] = cmd[i];
    }
    params[pLen] = '\0';
}

void parseLED(char* cmd) {
    int n = 0;
    char op[4];
    char params[4];

    parseCommand(cmd, op, params);
    if (!strcmp(params, "ALL")) {
        LED_Out(0xFF);
		return;
    }
    else {
        n = params[0] - '0';        // get value n
    }

    if (!strcmp(op, "ON")) {
        ptrLEDFunction(n, &LED_On);
    }
    else  if (!strcmp(op, "OFF")) {
        ptrLEDFunction(n, &LED_Off);
    }

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
/* End init */
///////////////////////////////////////////////

///////////////////////////////////////////////
/* Handler */ 
__irq void UART1_Handler() {
	int ch;
	ch = getkey();
	
	if (ch == 13) {
		__cmd[__ind][__len++] = '\0';
		// dang trong tinh trang chua co command
		if (mode == NA_CMD) {
			nl();
			getCommand();		// parse ra command va luu trong mode
		}
		else {
			nl();
			getCommand2();
		}
		__ind++;
		if (__ind == 11) {
			__ind = 10;
		}
		__len = 0;
	}
	else if (mode == NA_CMD && ch == 27) {
	}
	// truong hop bam esc va dang trong mode command
	else if (mode != NA_CMD && ch == 27) {
		mode = NA_CMD;		// reset lai mode
		nl();
		sendchar('>');		// in dau ngat	 		
	}
	else {
		sendchar(ch);	// send char vua type ra terminal
		// type binh thuong, append char vao trong chuoi command
		addCommand(ch);
	}
	

	EXTINT = 1;
	VICVectAddr = 0;
}
/* End Handler */ 
///////////////////////////////////////////////

///////////////////////////////////////////////
 /* Utils */
 int getkey (void) {
	while (!(U1LSR & 0x01));

	return U1RBR;
}

int sendchar (int ch) {
	while (!(U1LSR & 0x20));

	return (U1THR = ch);
}

void addCommand (int ch) {
	__cmd[__ind][__len++] = ch;
}

void getCommand(void) {
	if (!strcmp(__cmd[__ind], "LED")) {
		mode = LED;
		print("LED>");
	}
	else if (!strcmp(__cmd[__ind], "TIME")) {
		mode = TIME;
		print("TIME>");
	}
	else if (!strcmp(__cmd[__ind], "PIANO")) {
		mode = PIANO;
		print("PIANO>");
	}
	else if (!strcmp(__cmd[__ind], "CALC")) {
		mode = CALC;
		print("CALC>");
	}
	else if (!strcmp(__cmd[__ind], "HELP")) {
		print("HELP cmd");
		nl();
		sendchar('>');
		mode = NA_CMD;
	}
	else if (!strcmp(__cmd[__ind], "ME")) {
		print("Nguyen Hoang Vu");
		nl();
		sendchar('>');
		mode = NA_CMD;
	}
	else {
		mode = NA_CMD;
	}
}

void getCommand2(void) {
	switch (mode) {
	case LED:
		parseLED(__cmd[__ind]);
		print("LED>");
		break;
	case TIME:
		parseTIME(__cmd[__ind]);
		print("TIME>");
		break;
	case CALC:
		parseCALC(__cmd[__ind]);
		print("CALC>");
		break;
	case PIANO:
		print("PIANO>");
		break;
	}
}

void print(char *s) {
	int i = 0;
	while (s[i] != '\0') {
		sendchar(s[i]);
		i++;
	}
}

void nl() {
	sendchar(10);
	sendchar(13);
}

DateTime __DateTime;

void parseTIME(char *cmd) {
	char op[5];
	char params[20];

	parseCommand(cmd, op, params);
	if (!strcmp(op, "SET")) {
		printf(cmd);
		printf("\n");
		__DateTime = setDateTimeByString(params);
	}
	else if (!strcmp(op, "SHOW")) {
		printf("SHOW cmd.\n");
		printf("%2d:%2d:%4d", __DateTime.day, __DateTime.mon, __DateTime.year);
		printf(" %2d:%2d:%2d.\n", __DateTime.hour, __DateTime.hour, __DateTime.min, __DateTime.sec);
	}
}

int add(int n1, int n2) {
	return n1 + n2;
}

int sub(int n1, int n2) {
	return n1 - n2;
}

int mul(int n1, int n2) {
	return n1 * n2;
}

int div(int n1, int n2) {
	return n1 / n2;
}

int mod(int n1, int n2) {
	return n1 % n2;
}

void parseCALCCommand(char *cmd, char *op, int *n1, int *n2) {
	int i = 0;
	// n1
	*n1 = 0;	// reset n1
	while (cmd[i] != ' ') {
		*n1 += atoi(cmd[i]);
		i++;
		*n1 *= 10;
	}
	*n1 /= 10;
	// op
	// cmd[i] == ' ';
	i++;
	*op = cmd[i];
	i += 2;
	// n2
	*n2 = 0;	// reset n2
	while (cmd[i] != '\0') {
		*n2 += atoi(cmd[i]);
		i++;
		*n2 *= 10;
	}
	*n2 /= 10;
}

int ptrCalcFunction(int n1, int n2, int (*calc)(int n1, int n2)) {
	return calc(n1, n2);
}

void parseCALC(char *cmd) {
	char op;
	int n1 = 0, n2 = 0;

	parseCALCCommand(cmd, &op, &n1, &n2);

	if (op == '+') {
		printf("%d.\n", ptrCalcFunction(n1, n2, &add));
	}
	else if (op == '-') {
		printf("%d.\n", ptrCalcFunction(n1, n2, &sub));
	}
	else if (op == '*') {
		printf("%d.\n", ptrCalcFunction(n1, n2, &mul));
	}
	else if (op == '/') {
		printf("%d.\n", ptrCalcFunction(n1, n2, &div));
	}
	else if (op == '%') {
		printf("%d.\n", ptrCalcFunction(n1, n2, &mod));
	}
}

int atoi(char n) {
	return n - '0';
}

DateTime setDateTimeByString(char *params) {
	//         0123456789012345678
	// format: dd:MM:yyyy hh:mm:ss
	//
	int day, mon, year, hour, min, sec;

	day = atoi(params[0])*10 + atoi(params[1]);
	mon = atoi(params[3])*10 + atoi(params[4]);
	year = atoi(params[6])*1000 + atoi(params[7])*100 + atoi(params[8])*10 + atoi(params[9]);

	hour = atoi(params[11])*10 + atoi(params[12]);
	min = atoi(params[14])*10 + atoi(params[15]);
	sec = atoi(params[17])*10 + atoi(params[18]);

	return setDateTime(day, mon, year, hour, min, sec);
}

DateTime setDateTime(int day, int mon, int year, int hour, int min, int sec) {
	DateTime dt;

	dt.day = day;
	dt.mon = mon;
	dt.year = year;
	dt.hour = hour;
	dt.min = min;
	dt.sec = sec;

	return dt;
}

int main (void) {

	__ind = 0;
	__len = 0;
	//VICIntEnable = 0;

	LED_Init();
	UART1_Init();

	LED_Out(0x00);

	sendchar('>');

	while (1) ;
}
