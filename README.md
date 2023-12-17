# Fund Transfer Microservice

This project intends to be a simple worker implementation offering solution to this [Challenge](./docs/CHALLENGE.md).

The main idea is use some principles:

 * DRY - Don't Reinvent the Wheel
 * KISS - Keep It Simple Sir :)
 * MVP - Minimum Viable Product

This project aims to deliver:

 * an worker to process fund transfer available on a queue
 * a chain of responsibility implementation
 
## Installing, testing and running

To run this solution you'll need have make in your system.

### Install

Change to your project directory and clone this repo.

``` bash
$ cd ~/your/projects/direcotory
$ git clone https://github.com/mmc-marcominas/charge-account-manager
```

Go to created directory and then.

``` bash
$ cd ~/your/projects/direcotory/charge-account-manager
$ make all
```

### Run project

``` bash
$ cd ~/your/projects/direcotory/charge-account-manager/
$ make run
```

or

``` bash
$ cd ~/your/projects/direcotory/charge-account-manager/
$ dotnet run
```

### Run tests

To perform test `run project` must be executede and running.

### Test charge account manager implementation

``` bash
$ cd ~/your/projects/direcotory/charge-account-manager/
$ make run
```

Expected result:

``` json
{
  "transactionId": "bdfedcdd-d9c5-4781-9671-c23cd01873c2"
}
```


See [CHALLENGE.md#problema](CHALLENGE.md#problema) section to possible status list.

 ## MVP history

  * [mvp-01](./docs/mvp-01.md) - basic worker implementation
  * [mvp-02](./docs/mvp-02.md) - add chain of responsibility pattern
