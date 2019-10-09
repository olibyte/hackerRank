class Polygon {
    constructor(sides) {
        this.sides = sides;
    }
  
    perimeter() {
      return this.sides.reduce((sum, side) => sum + side, 0);
    }
  }