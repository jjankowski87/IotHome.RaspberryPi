# IotHome.RaspberryPi ![.NET Core](https://github.com/jjankowski87/IotHome.RaspberryPi/workflows/.NET%20Core/badge.svg)
IoT temperature sensor based on RaspberryPi3, written in .NET Core

## Installation
1. Install raspbian OS on RaspberryPi device
2. Install .NET Core Runtime on RaspberryPi device 
    - download avalaible at [microsoft pages](https://dotnet.microsoft.com/download/dotnet-core)
    - select Linux/ARM32 version
    - install in ```/home/pi/dotnet``` directory 
    - add ```DOTNET_ROOT``` environment variable pointing to dotnet installation directory
3. Generate application binaries
    - open project in Visual Studio
    - in Package Manager Console enter following command: ```dotnet publish -r linux-arm -c Release --self-contained false```
4. Copy binaries to RaspberryPi device
    - binaries location ```IotHome.RaspberryPi.Console\bin\Release\netcoreappX.X\linux-arm\publish```
    - copy to ```/home/pi/Apps/IotHome.RaspberryPi``` directory
    - coulde be copied using WinSCP application
5. Modify appsettings.json file to reflect your needs
    - ```ConnectionString``` device connection string to Azure IoT Hub service
    - ```ProcessingIntervalInSeconds```
    - ```Logs directory```
    - ```SensorSettings``` enable/disable desired sensors, currently supported sensors: chipset temperature, DS18B20 and random (for testing purposes)
6. Add execution rights for ```IotHome.RaspberryPi.Console``` app
    - ```chmod 777 IotHome.RaspberryPi.Console```
7. Start app
    - ```./IotHome.RaspberryPi.Console```

## Autostart 
1. Create ```RunIotHome.sh``` file in application directory with content
    - ```DOTNET_ROOT=/home/pi/dotnet /home/pi/Apps/IotHome.RaspberryPi/IotHome.RaspberryPi.Console```
2. Add execution rights for newly created script ```chmod 777 RunIotHome.sh```
3. Go to ```/home/pi/.config/autostart```, create if doesn't exist
4. Create ```RunIotHome.desktop``` file, with following content:
```
[Desktop Entry]
Type=Application
Name=IotHome.RaspberryPi
Exec=/home/pi/Apps/IotHome.RaspberryPi/RunIotHome.sh
```
5. Application should start after reboot, if not check logs

## Sensor configuration
1. Connect sensor DS18B20 via 1 wire interface
2. Run ```raspi-config``` and enable 1 wire
    - Interfacing options
    - 1-Wire
    - reboot device
    - you can check whether sensor is properly connected by running ```lsmod``` command, ```w1_gpio``` and ```w1_therm``` should be visible
3. List avalaible devices by ```ls /sys/bus/w1/devices``
4. Entry like ```28-000008d6bac6``` is our sensor address, copy it to appsettings.json file
