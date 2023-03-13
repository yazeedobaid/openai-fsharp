module Tests.Fixtures.Chat

let createChatResponse () =
    """
    {
        "id": "chatcmpl-6tglhbeckbOU4FW34NH25Bo8Sa6SW",
        "object": "chat.completion",
        "created": 1678730461,
        "model": "gpt-3.5-turbo-0301",
        "usage": {
            "prompt_tokens": 9,
            "completion_tokens": 11,
            "total_tokens": 20
        },
        "choices": [
            {
                "message": {
                    "role": "assistant",
                    "content": "\n\nHello, how can I assist you today?"
                },
                "finish_reason": "stop",
                "index": 0
            }
        ]
    }
    """
