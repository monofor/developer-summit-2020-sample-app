const productStubs = [
    {
        predicates: [
            {
                equals: {
                    method: "GET",
                    path: "/products",
                },
            },
        ],
        responses: [
            {
                is: {
                    statusCode: 200,
                    headers: {"Content-Type": "application/json"},
                    body: JSON.stringify({
                        success: true,
                        data: [
                            {
                                productId: "8F11AD71-D7E7-45EF-AF9E-D54EF0675C77",
                                code: "iPhone",
                                name: "iPhone 12",
                                price: 14550
                            },
                            {
                                productId: "463089DA-12B7-4975-ABC2-F7C785486644",
                                code: "macbook",
                                name: "Macbook Pro 16'",
                                price: 34521
                            }
                        ],
                    }),
                },
            },
        ],
    }
];

module.exports = productStubs;