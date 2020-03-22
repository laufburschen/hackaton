export class Product {
    public name     :string;
    public count    :number;
    public price    :number;
    constructor(name, count, price){
        this.price = price;
        this.count = count;
        this.name  = name;
    }
}
