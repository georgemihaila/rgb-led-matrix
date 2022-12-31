export class VirtualMatrixConfiguration {
    public getUsableWidth: any;
    public getUsableHeight: any;
    public getHeight: any;
    constructor(
        public widthPixels: number,
        public heightPixels: number,
        public canvasWidth: number = 300,
        public paddingThickness: number = 1) {
        this.getUsableWidth = () => {
            return this.canvasWidth - 2 * this.paddingThickness;
        }
        this.getHeight = () => {
            return (this.canvasWidth / this.widthPixels) * this.heightPixels;
        }
        this.getUsableHeight = () => {
            return this.getHeight() - 2 * this.paddingThickness
        }
    }
}