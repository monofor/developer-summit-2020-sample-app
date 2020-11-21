import {shallowMount} from "@vue/test-utils";
import Product from "@/components/Product.vue";

describe("Product.vue", () => {
    it("renders product title when passed", () => {
        const wrapper = shallowMount(Product, {
            propsData: {
                product: {
                    productId: "8F11AD71-D7E7-45EF-AF9E-D54EF0675C77",
                    code: "iPhone",
                    name: "iPhone 12",
                    price: 14550
                },
                index: 0
            }
        });

        const title = wrapper.find(".card-title");
        expect(title.element.innerHTML).toBe("iPhone 12");
    });

    it("renders product code when passed", () => {
        const wrapper = shallowMount(Product, {
            propsData: {
                product: {
                    productId: "8F11AD71-D7E7-45EF-AF9E-D54EF0675C77",
                    code: "iPhone",
                    name: "iPhone 12",
                    price: 14550
                },
                index: 0
            }
        });

        const code = wrapper.find(".card-text");
        expect(code.element.innerHTML).toBe("Code: iPhone");
    });
});
