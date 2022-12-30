
export class Color {
    constructor(public r: Number, public g: Number, public b: Number) {

    }

    public static getRandom(): Color {
        return new Color(1000 * Math.random() % 255, 1000 * Math.random() % 255, 1000 * Math.random() % 255);
    }
}