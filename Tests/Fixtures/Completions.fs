module Tests.Fixtures.Completions

let createCompletionResponse () =
    """
    {
        "id": "cmpl-6dOr2P1HmXdbpmkKH06thLQqCAoHH",
        "object": "text_completion",
        "created": 1674848352,
        "model": "text-davinci-003",
        "choices": [
            {
                "text": " an oblate spheroid.",
                "index": 0,
                "logprobs": {
                    "tokens": [
                        " an",
                        " ob",
                        "late",
                        " sp",
                        "he",
                        "roid",
                        "."
                    ],
                    "token_logprobs": [
                        -0.47306553,
                        -0.5620347,
                        -0.0030493317,
                        -0.016009098,
                        -0.008609015,
                        -0.000045255874,
                        -0.3398966
                    ],
                    "top_logprobs": [
                        {
                            " an": -0.47306553
                        },
                        {
                            " ob": -0.5620347
                        },
                        {
                            "late": -0.0030493317
                        },
                        {
                            " sp": -0.016009098
                        },
                        {
                            "he": -0.008609015
                        },
                        {
                            "roid": -0.000045255874
                        },
                        {
                            ".": -0.3398966
                        }
                    ],
                    "text_offset": [
                        24,
                        27,
                        30,
                        34,
                        37,
                        39,
                        43
                    ]
                },
                "finish_reason": "length"
            }
        ],
        "usage": {
            "prompt_tokens": 6,
            "completion_tokens": 7,
            "total_tokens": 13
        }
    }
    """
