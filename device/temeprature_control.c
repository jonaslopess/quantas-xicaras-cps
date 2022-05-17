char control_data[5];
char temp_data[8];
unsigned int temp_raw;
float temp;

int cont = 5;

void main() {

  ADCON1 = 0b00001100;
  ADC_Init();
  
  TRISD = 0;
  TRISB = 0;
  PORTB = 0;
  PORTD = 0;
  TRISC.RC2 = 0;
  PORTC.RC2 = 0;

  UART1_Init(9600);

  while(1){
    
    if(UART1_Data_Ready() == 1){
      UART1_Read_Text(control_data, "]", 10);

      if(control_data[0] == '['){
        if(control_data[1] == 'C'){
          if(control_data[2] == '1'){
            PORTC.RC2 = 1;
          }
          if(control_data[2] == '0'){
            PORTC.RC2 = 0;
          }
        }
        if(control_data[1] == 'T'){
          temp_raw = ADC_Get_Sample(2);
          temp = (temp_raw*4.9)/10.0;
          FloatToStr(temp,temp_data);
          Ltrim(temp_data);

          UART1_Write_Text(temp_data);
          UART1_Write_Text("\n");

        }
      }
    }

  }



}