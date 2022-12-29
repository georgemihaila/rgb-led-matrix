
## A framework for building and displaying animations on RGB displays using Raspberry Pis

### Dependencies

1. [rgb-led-matrix](https://github.com/hzeller/rpi-rgb-led-matrix)
2. [.NET Core 6.0](https://levelup.gitconnected.com/install-the-net-6-0-sdk-on-a-raspberry-pi-in-two-easy-steps-27993c1bd68d)
3. An instance of [RabbitMQ](https://www.rabbitmq.com/) running anywhere on your local network (can be on the RPi itself, I just used a VM that already had it installed)

### Setup
1. Log into the RPi and set up rpi-rgb-led-matrix into the ~ directory as root user
`sudo su -`
`cd /home/pi`
`git clone https://github.com/hzeller/rpi-rgb-led-matrix`
`cd rpi-rgb-led-matrix`
Make sure all dependencies are installed
`make all`
`cd bindings/c#`
`make all`

