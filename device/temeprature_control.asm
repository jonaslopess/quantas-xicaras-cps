
_main:

;temeprature_control.c,8 :: 		void main() {
;temeprature_control.c,10 :: 		ADCON1 = 0b00001100;
	MOVLW       12
	MOVWF       ADCON1+0 
;temeprature_control.c,11 :: 		ADC_Init();
	CALL        _ADC_Init+0, 0
;temeprature_control.c,13 :: 		TRISD = 0;
	CLRF        TRISD+0 
;temeprature_control.c,14 :: 		TRISB = 0;
	CLRF        TRISB+0 
;temeprature_control.c,15 :: 		PORTB = 0;
	CLRF        PORTB+0 
;temeprature_control.c,16 :: 		PORTD = 0;
	CLRF        PORTD+0 
;temeprature_control.c,17 :: 		TRISC.RC2 = 0;
	BCF         TRISC+0, 2 
;temeprature_control.c,18 :: 		PORTC.RC2 = 0;
	BCF         PORTC+0, 2 
;temeprature_control.c,20 :: 		UART1_Init(9600);
	BSF         BAUDCON+0, 3, 0
	CLRF        SPBRGH+0 
	MOVLW       207
	MOVWF       SPBRG+0 
	BSF         TXSTA+0, 2, 0
	CALL        _UART1_Init+0, 0
;temeprature_control.c,22 :: 		while(1){
L_main0:
;temeprature_control.c,24 :: 		if(UART1_Data_Ready() == 1){
	CALL        _UART1_Data_Ready+0, 0
	MOVF        R0, 0 
	XORLW       1
	BTFSS       STATUS+0, 2 
	GOTO        L_main2
;temeprature_control.c,25 :: 		UART1_Read_Text(control_data, "]", 10);
	MOVLW       _control_data+0
	MOVWF       FARG_UART1_Read_Text_Output+0 
	MOVLW       hi_addr(_control_data+0)
	MOVWF       FARG_UART1_Read_Text_Output+1 
	MOVLW       ?lstr1_temeprature_control+0
	MOVWF       FARG_UART1_Read_Text_Delimiter+0 
	MOVLW       hi_addr(?lstr1_temeprature_control+0)
	MOVWF       FARG_UART1_Read_Text_Delimiter+1 
	MOVLW       10
	MOVWF       FARG_UART1_Read_Text_Attempts+0 
	CALL        _UART1_Read_Text+0, 0
;temeprature_control.c,27 :: 		if(control_data[0] == '['){
	MOVF        _control_data+0, 0 
	XORLW       91
	BTFSS       STATUS+0, 2 
	GOTO        L_main3
;temeprature_control.c,28 :: 		if(control_data[1] == 'C'){
	MOVF        _control_data+1, 0 
	XORLW       67
	BTFSS       STATUS+0, 2 
	GOTO        L_main4
;temeprature_control.c,29 :: 		if(control_data[2] == '1'){
	MOVF        _control_data+2, 0 
	XORLW       49
	BTFSS       STATUS+0, 2 
	GOTO        L_main5
;temeprature_control.c,30 :: 		PORTC.RC2 = 1;
	BSF         PORTC+0, 2 
;temeprature_control.c,31 :: 		}
L_main5:
;temeprature_control.c,32 :: 		if(control_data[2] == '0'){
	MOVF        _control_data+2, 0 
	XORLW       48
	BTFSS       STATUS+0, 2 
	GOTO        L_main6
;temeprature_control.c,33 :: 		PORTC.RC2 = 0;
	BCF         PORTC+0, 2 
;temeprature_control.c,34 :: 		}
L_main6:
;temeprature_control.c,35 :: 		}
L_main4:
;temeprature_control.c,36 :: 		if(control_data[1] == 'T'){
	MOVF        _control_data+1, 0 
	XORLW       84
	BTFSS       STATUS+0, 2 
	GOTO        L_main7
;temeprature_control.c,37 :: 		temp_raw = ADC_Get_Sample(2);
	MOVLW       2
	MOVWF       FARG_ADC_Get_Sample_channel+0 
	CALL        _ADC_Get_Sample+0, 0
	MOVF        R0, 0 
	MOVWF       _temp_raw+0 
	MOVF        R1, 0 
	MOVWF       _temp_raw+1 
;temeprature_control.c,38 :: 		temp = (temp_raw*4.9)/10.0;
	CALL        _word2double+0, 0
	MOVLW       205
	MOVWF       R4 
	MOVLW       204
	MOVWF       R5 
	MOVLW       28
	MOVWF       R6 
	MOVLW       129
	MOVWF       R7 
	CALL        _Mul_32x32_FP+0, 0
	MOVLW       0
	MOVWF       R4 
	MOVLW       0
	MOVWF       R5 
	MOVLW       32
	MOVWF       R6 
	MOVLW       130
	MOVWF       R7 
	CALL        _Div_32x32_FP+0, 0
	MOVF        R0, 0 
	MOVWF       _temp+0 
	MOVF        R1, 0 
	MOVWF       _temp+1 
	MOVF        R2, 0 
	MOVWF       _temp+2 
	MOVF        R3, 0 
	MOVWF       _temp+3 
;temeprature_control.c,39 :: 		FloatToStr(temp,temp_data);
	MOVF        R0, 0 
	MOVWF       FARG_FloatToStr_fnum+0 
	MOVF        R1, 0 
	MOVWF       FARG_FloatToStr_fnum+1 
	MOVF        R2, 0 
	MOVWF       FARG_FloatToStr_fnum+2 
	MOVF        R3, 0 
	MOVWF       FARG_FloatToStr_fnum+3 
	MOVLW       _temp_data+0
	MOVWF       FARG_FloatToStr_str+0 
	MOVLW       hi_addr(_temp_data+0)
	MOVWF       FARG_FloatToStr_str+1 
	CALL        _FloatToStr+0, 0
;temeprature_control.c,40 :: 		Ltrim(temp_data);
	MOVLW       _temp_data+0
	MOVWF       FARG_Ltrim_string+0 
	MOVLW       hi_addr(_temp_data+0)
	MOVWF       FARG_Ltrim_string+1 
	CALL        _Ltrim+0, 0
;temeprature_control.c,42 :: 		UART1_Write_Text(temp_data);
	MOVLW       _temp_data+0
	MOVWF       FARG_UART1_Write_Text_uart_text+0 
	MOVLW       hi_addr(_temp_data+0)
	MOVWF       FARG_UART1_Write_Text_uart_text+1 
	CALL        _UART1_Write_Text+0, 0
;temeprature_control.c,43 :: 		UART1_Write_Text("\n");
	MOVLW       ?lstr2_temeprature_control+0
	MOVWF       FARG_UART1_Write_Text_uart_text+0 
	MOVLW       hi_addr(?lstr2_temeprature_control+0)
	MOVWF       FARG_UART1_Write_Text_uart_text+1 
	CALL        _UART1_Write_Text+0, 0
;temeprature_control.c,45 :: 		}
L_main7:
;temeprature_control.c,46 :: 		}
L_main3:
;temeprature_control.c,47 :: 		}
L_main2:
;temeprature_control.c,49 :: 		}
	GOTO        L_main0
;temeprature_control.c,53 :: 		}
L_end_main:
	GOTO        $+0
; end of _main
