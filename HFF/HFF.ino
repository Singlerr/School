#include<MPU6050_tockn.h>
#include<Wire.h>
float time,prevTime;
float angle = 0;
MPU6050 mpu(Wire);
void setup() {
  Serial.begin(115200);
  Wire.begin();
  mpu.begin();
  mpu.setGyroOffsets(-26.03,1.71,-3.11);
  time = millis();
}
float differentiate(float prev,float current,float time,float prevTime){
  return (current-prev)/(time-prevTime);
}
void loop() {
  mpu.update();
 float ca = mpu.getAngleX();
  float deriative = ca - angle;
  if(ca >= 20){
   Serial.print("U");Serial.print("\n");
  }else{
   
    if(deriative > 0){
      Serial.print(deriative);Serial.print("\n");
    }else{
     Serial.print("N");Serial.print("\n");
  }
  }
  angle = ca;
  delay(10);
}
