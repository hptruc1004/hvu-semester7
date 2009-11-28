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
#include <string.h>

 void temp();
 void h_CopyNum(int val,char *des)	  ;
 char command[50];
 int len ;
int wdt_counter;


 typedef struct {
    short RTC_Sec;     /* Second value - [0,59] */
    short RTC_Min;     /* Minute value - [0,59] */
    short RTC_Hour;    /* Hour value - [0,23] */
    short RTC_Mday;    /* Day of the month value - [1,31] */
    short RTC_Mon;     /* Month value - [1,12] */
    short RTC_Year;    /* Year value - [0,4095] */
    short RTC_Wday;    /* Day of week value - [0,6] */
    short RTC_Yday;    /* Day of year value - [1,365] */
} RTCTime;

 RTCTime t;
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


/* Function for displaying bargraph on the LCD display                        */
void Disp_Bargraph(int pos_x, int pos_y, int value) {
  int i;

  set_cursor (pos_x, pos_y);
  for (i = 0; i < 16; i++)  {
    if (value > 5)  {
      lcd_putchar (0x05);
      value -= 5;
    }  else  {
      lcd_putchar (value);
      value = 0;
    }
  }
}

/* Import external IRQ handlers from IRQ.c file                               */
extern __irq void T0_IRQHandler  (void);
extern __irq void ADC_IRQHandler (void);

/* Import external functions from Serial.c file                               */
extern       void init_serial    (void);

/* Import external variables from IRQ.c file                                  */
extern short AD_last;
extern unsigned char clock_1s;

void temp()
{
	int dd;
	dd=9;
	dd+=2;dd+=3;

}
void temp1()
{
	int dd1;
	temp();

}
void h_CopyNum(int val,char *des)
{
	int v;
	char c;	
	v = val;		
	c += '0';
	*des = c;
}
void Xuly()
{
//	if()
}
void Loi()
{
	char *error1;
	int i;
    
	error1="\n\rLenh khong duoc tim thay !";
	for(i=0;i<30;i++);
		sendchar(error1);
}

#define PREINT_RTC	0x000001C8  /* Prescaler value, integer portion, 
				    PCLK = 15Mhz */
#define PREFRAC_RTC	0x000061C0  /* Prescaler value, fraction portion, 
				    PCLK = 15Mhz */

#define ILR_RTCCIF	0x01
#define ILR_RTCALF	0x02

#define CCR_CLKEN	0x01
#define CCR_CTCRST	0x02
#define CCR_CLKSRC	0x10



void RTCInit( void )
{
//  alarm_on = 0;

  /*--- Initialize registers ---*/    
  //RTC_AMR = 0;
  //RTC_CIIR = 0;
  RTC_CCR = 0;
  RTC_PREINT = PREINT_RTC;	 //456
  RTC_PREFRAC = PREFRAC_RTC; //	  25024
  return;
}

void RTCGetTime( RTCTime* LocalTime ) 
{
	if ( LocalTime == NULL ) return;

	LocalTime->RTC_Sec  = RTC_SEC;
	LocalTime->RTC_Min  = RTC_MIN;
	LocalTime->RTC_Hour = RTC_HOUR;
	LocalTime->RTC_Mday = RTC_DOM;
	LocalTime->RTC_Wday = RTC_DOW;
	LocalTime->RTC_Yday = RTC_DOY;
	LocalTime->RTC_Mon  = RTC_MONTH;
	LocalTime->RTC_Year = RTC_YEAR;
	return;
}

void RTCSetTime( RTCTime Time ) 
{
  RTC_SEC   = Time.RTC_Sec;
  RTC_MIN   = Time.RTC_Min;
  RTC_HOUR  = Time.RTC_Hour;
  RTC_DOM   = Time.RTC_Mday;
  RTC_DOW   = Time.RTC_Wday;
  RTC_DOY   = Time.RTC_Yday;
  RTC_MONTH = Time.RTC_Mon;
  RTC_YEAR  = Time.RTC_Year;    
  return;
}

void RTCStart( void ) 
{
  /*--- Start RTC counters ---*/
  RTC_CCR |= CCR_CLKEN;		  //0x01


 // RTC_ILR = ILR_RTCCIF;	   //0x01
  return;
}

 void WDTFeed( void )
{
  WDFEED = 0xAA;		/* Feeding sequence */
  WDFEED = 0x55;
  return;
}

 void abc()__irq
 {
 RTCGetTime( &t);
	printf("%d:%d:%d",t.RTC_Hour,t.RTC_Min,t.RTC_Sec);

  
//  WDTFeed();
	  T0IR        = 1;                      /* Clear interrupt flag               */
  VICVectAddr = 0; 
 }




void WDTHandler(void) __irq 
{
  WDMOD &= ~0x00000004;		/* clear the time-out terrupt flag */		  
  //IENABLE;			/* handles nested interrupt */
  wdt_counter++;
//  IDISABLE;
sendchar('P');


  VICVectAddr = 0;		/* Acknowledge Interrupt */
}


int WDTInit( void )
{
  wdt_counter = 0;
/*  if ( install_irq( 0, (void *)WDTHandler, 0 ) == 0 )
  {
	return (0);
  }*/


    VICVectAddr0  = (unsigned long)WDTHandler;/* Set Interrupt Vector        */
  VICVectCntl0  = 0;                          /* use it for Timer0 Interrupt */
  VICIntEnable  = (1  << 0);                   /* Enable Timer0 Interrupt     */



  //WDTC = 0x003Fffff ;	/* once WDEN is set, the WDT will start after feeding */
  WDTC = 0x0fFf ;	/* once WDEN is set, the WDT will start after feeding */
//  WDMOD = WDEN | WDRESET;
  WDMOD = 0x03;

  WDFEED = 0xAA;		/* Feeding sequence */
  WDFEED = 0x55;    
  return( 0 );
}


int a,b,c,d;


int main (void) {
  int i,j;
  	
  short AD_old, AD_value, AD_print;
  
  char k;
  LED_Init();  
  lcd_init();

  //	WDTInit();
	t.RTC_Sec = 20;
	t.RTC_Min = 20;
	t.RTC_Hour = 20;

  RTCInit();
   RTCStart();
	init_serial(); 
	RTCSetTime(t);
	


// temp1();
//i= cong();
//  /* Enable and setup timer interrupt, start timer                            */
#if 1
  T0MR0         = 11999000;                       /* 1msec = 12000-1 at 12.0 MHz */
  T0MCR         = 3;                           /* Interrupt and Reset on MR0  */
  T0TCR         = 1;                           /* Timer0 Enable               */
  VICVectAddr4  = (unsigned long)abc;/* Set Interrupt Vector        */
  VICVectCntl4  = 15;                          /* use it for Timer0 Interrupt */
  VICIntEnable  = (1  << 4);                   /* Enable Timer0 Interrupt     */
#endif 
 //
//  /* Power enable, Setup pin, enable and setup AD converter interrupt         */
//  PCONP        |= (1 << 12);                   /* Enable power to AD block    */
//  PINSEL1       = 0x4000;                      /* AD0.0 pin function select   */
//  AD0INTEN      = (1 <<  0);                   /* CH0 enable interrupt        */
//  AD0CR         = 0x00200301;                  /* Power up, PCLK/4, sel AD0.0 */
//  VICVectAddr18 = (unsigned long)ADC_IRQHandler;/* Set Interrupt Vector       */
//  VICVectCntl18 = 14;                          /* use it for ADC Interrupt    */
//  VICIntEnable  = (1  << 18);                  /* Enable ADC Interrupt        */
//
//  init_serial();                               /* Init UART                   */
//
//  lcd_init();
//  lcd_clear();
//  lcd_print ("  MCB2300 DEMO  ");
//  set_cursor (0, 1);
//  lcd_print ("  www.keil.com  ");
//
// printf ("AD value");
//  for (i = 0; i < 20000000; i++);       /* Wait for initial display           */

//  while (1) {                           /* Loop forever                       */
//    AD_value = AD_last;                 /* Read AD_last value                 */
//    if (AD_value != AD_last)            /* Make sure that AD interrupt did    */
//      AD_value = AD_last;               /* not interfere with value reading   */
//    AD_print  = AD_value;               /* Get unscaled value for printout    */
//    AD_value /= 13;                     /* Scale to AD_Value to 0 - 78        */
//    if (AD_old != AD_value)  {          /* If AD value has changed            */
//      AD_old = AD_value;
//      Disp_Bargraph(0, 1, AD_value);    /* Display bargraph according to AD   */
//    }
//    if (clock_1s) {
//      clock_1s = 0;
//      printf ("AD value = 0x%03x\n\r", AD_print);
//    }
//  }


	sendchar('a');
	sendchar('>');

   //  for(i=0;i<1000;i++);
	// WDTFeed();
   while(1){};
#if 0	
while(1)
{
	a= getkey();

	
	switch (i)
	{		
		case 0x08: // back space
			// move left 1 char
			if(len>0)
			{
				sendchar(0x1b);   
				sendchar(0x5b);			
				sendchar('D');
	
				sendchar(' ');	   //clear char
	
				// move left 1 char
				sendchar(0x1b);   
				sendchar(0x5b);			
				sendchar('D');

				len--;

			}
			
			break;
		case 0x0D:
			if(len==0)
				break;
			Xuly();
			sendchar('\n');			
			sendchar('\r');			
			sendchar('>');			
			len=0;
			break;
		default:
			if((i>48 && i<122) || i==32)
			{	
				command[len]=i;
				len++;
				sendchar(i);
			}
			break;
						   	
	} 
			/*	sendchar('a');
				sendchar('c');
				sendchar('b');
				sendchar(0x1b);   
   				sendchar(0x45);*/

	
}
LED_Out(0x00);
lcd_clear();
//LED_On(1);
//FIO2SET=0x01;
  	
 
//	   for (i = 0; i < 8; i++)
//	   {
//			for (j = 0; j < 500000; j++);
//			LED_Out(0x00);
//			LED_On(i);
//
//			lcd_clear();
//			for (j = 0; j < 500000; j++);
//			set_cursor (i, 0);
//			k= i + '0';
//			lcd_putchar (k);
//	  
//
//	   }
//	   i=0;
#endif
 
}
