/*
 * Stepper_bipolar sketch
 *
 * stepper is controlled from the serial port.
 * a positive numeric value steps in one direction.
 * a negative numeric value steps in the opposite direction.
 *
 * http://www.arduino.cc/en/Reference/Stepper
 */

#include <Stepper.h>

// change this to the number of steps per revolution for your motor
#define STEPS 200

// create an instance of the stepper class, specifying
// the number of steps per evolutioon fr the motor and 
// the pins it'sattached to
Stepper stepper(STEPS, 2, 3, 4, 5);

int steps = 0;


void setup()
{
  // set the speed of the motor to 10 RPM
  stepper.setSpeed(10);
  Serial.begin(9600);
}


 void loop(){
if (Serial.available()>0){ 
steps = Serial.parseInt();
}
if( steps != 0){
   stepper.step(steps);
 }
 steps=0;
}


