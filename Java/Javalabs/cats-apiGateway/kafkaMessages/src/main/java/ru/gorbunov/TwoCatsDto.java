package ru.gorbunov;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class TwoCatsDto {
    private final long firstCatId;
    private final long secondCatId;
}
