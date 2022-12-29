
## A framework for building and displaying animations on RGB displays using Raspberry Pis

### Dependencies

1. [rgb-led-matrix](https://github.com/hzeller/rpi-rgb-led-matrix)
2. [.NET Core 6.0](https://levelup.gitconnected.com/install-the-net-6-0-sdk-on-a-raspberry-pi-in-two-easy-steps-27993c1bd68d)
3. An instance of [RabbitMQ](https://www.rabbitmq.com/) running anywhere on your local network (can be on the RPi itself, I just used a VM that already had it installed)

### Setup
1. Set up `rgb-led-matrix` at `/home/pi`

Log into the RPi  as `root`

`sudo su -`

`cd /home/pi`

`git clone https://github.com/hzeller/rpi-rgb-led-matrix`

`cd rpi-rgb-led-matrix`

Make sure all dependencies are installed

`make all`

`cd bindings/c#`

`make all`

We have now build the dependencies the project will use in order to control the matrices

2. Set up the project

Make sure `.NET core 6.0` is installed by running `dotnet --version`

`cd ~`

`git clone https://github.com/georgemihaila/rgb-led-matrix`

`cd rgb-led-matrix`

`cp scripts/update.sh ../update.sh`

Prepare linux services

`cp -R linux-services/* /etc/systemd/system`

`systemctl daemon-reload`

`systemctl enable matrixrunner`

`systemctl enable matrixserver`

Allow web API port 5050 through the firewall

`ufw allow 5050`

Update and build the solution.  This script automatically manages the background services; whenever there is an update you can just run it again

`cd ../`

`chmod +x update.sh`

`./update.sh`

Done. The web API should be available on the local network at `http://[ip]:5050`
