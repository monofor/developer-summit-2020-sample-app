import {shallowMount} from "@vue/test-utils";
import Products from "@/components/Products.vue";

describe("Products.vue", () => {
    it("has a mounted hook", () => {
        expect(typeof Products.mounted).toBe("function");
    });

    it("renders product title when passed", async () => {
        const wrapper = shallowMount(Products);
        await wrapper.vm.getProducts();

        expect(wrapper.vm.products.length).toBe(2);
    });
});
