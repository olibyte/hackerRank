interface Syrupable {
    void getSugary();
}
abstract class Pancake implements Syrupable { }

class BlueBerryPanCake implements Pancake {
    public void getSugary() { ; }
}
class SourdoughBlueBerryPancake extends BlueBerryPanCake {
    void getSugary(int s) { ; }
}

/* Here is a comment **** */
/* This /* more */ */
/* // */
// /* // // */