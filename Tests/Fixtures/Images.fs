module Tests.Fixtures.Images

let createImageResponse () =
    """
    {
        "created": 1675158232,
        "data": [
            {
                "url": "https://oaidalleapiprodscus.blob.core.windows.net/private/org-HqJyr2hpU71AGbpla5U79HFg/user-Df4XsanElYDHBJY9W09xTwHe/img-CZtlItUeHHpqHw7BUjyTToYS.png?st=2023-01-31T08%3A43%3A52Z&se=2023-01-31T10%3A43%3A52Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-01-30T22%3A19%3A58Z&ske=2023-01-31T22%3A19%3A58Z&sks=b&skv=2021-08-06&sig=Yx6QzAY/PC1fA3OjYbMWmd5vQrkZ3yxPNnkEtgA2wSQ%3D"
            },
            {
                "url": "https://oaidalleapiprodscus.blob.core.windows.net/private/org-HqJyr2hpU71AGbpla5U79HFg/user-Df4XsanElYDHBJY9W09xTwHe/img-4ARY2KIIqdkzA9QQnt1NGBG3.png?st=2023-01-31T08%3A43%3A52Z&se=2023-01-31T10%3A43%3A52Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-01-30T22%3A19%3A58Z&ske=2023-01-31T22%3A19%3A58Z&sks=b&skv=2021-08-06&sig=KQvtM5Rb9EyeWWRHUWsvBnhuGUE7g8%2B/CyfzRVDAuHo%3D"
            }
        ]
    }
    """

let editImageResponse () =
    """
    {
        "created": 1675160644,
        "data": [
            {
                "url": "https://oaidalleapiprodscus.blob.core.windows.net/private/org-HqJyr2hpU71AGbpla5U79HFg/user-Df4XsanElYDHBJY9W09xTwHe/img-rPbnuUoBAFXfoPWayJszKHDk.png?st=2023-01-31T09%3A24%3A04Z&se=2023-01-31T11%3A24%3A04Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-01-30T22%3A17%3A59Z&ske=2023-01-31T22%3A17%3A59Z&sks=b&skv=2021-08-06&sig=Ub7AajqzM%2BVqOLjHu6K8D1Cf1kdHQN/tIY/EBLLkgrk%3D"
            },
            {
                "url": "https://oaidalleapiprodscus.blob.core.windows.net/private/org-HqJyr2hpU71AGbpla5U79HFg/user-Df4XsanElYDHBJY9W09xTwHe/img-VxHZNlMB9HJ2OZpnG2CGNrME.png?st=2023-01-31T09%3A24%3A04Z&se=2023-01-31T11%3A24%3A04Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-01-30T22%3A17%3A59Z&ske=2023-01-31T22%3A17%3A59Z&sks=b&skv=2021-08-06&sig=S05PkAOL/eU4YoOxX7quVjulC%2BwciXzLEPEezh%2BnJO0%3D"
            }
        ]
    }
    """

let variationImageResponse () =
    """
    {
        "created": 1675160816,
        "data": [
            {
                "url": "https://oaidalleapiprodscus.blob.core.windows.net/private/org-HqJyr2hpU71AGbpla5U79HFg/user-Df4XsanElYDHBJY9W09xTwHe/img-v8RyPQoA9BtmAzbbWFtGPnvs.png?st=2023-01-31T09%3A26%3A56Z&se=2023-01-31T11%3A26%3A56Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-01-30T22%3A20%3A52Z&ske=2023-01-31T22%3A20%3A52Z&sks=b&skv=2021-08-06&sig=n9fBFiQlI6ftcknJdFJENG4PHXNORPP2OpPdgBnl46E%3D"
            },
            {
                "url": "https://oaidalleapiprodscus.blob.core.windows.net/private/org-HqJyr2hpU71AGbpla5U79HFg/user-Df4XsanElYDHBJY9W09xTwHe/img-bnCpDrwit0tuWkELWK3AIFYD.png?st=2023-01-31T09%3A26%3A56Z&se=2023-01-31T11%3A26%3A56Z&sp=r&sv=2021-08-06&sr=b&rscd=inline&rsct=image/png&skoid=6aaadede-4fb3-4698-a8f6-684d7786b067&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2023-01-30T22%3A20%3A52Z&ske=2023-01-31T22%3A20%3A52Z&sks=b&skv=2021-08-06&sig=hhoKhddMKM1ZUqgGwFvWfyxYhWwCHJrRDqYRQSEIG3M%3D"
            }
        ]
    }
    """
