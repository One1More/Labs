package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import ru.gorbunov.contracts.CatsService;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.models.Breeds;
import ru.gorbunov.models.Colors;

import java.time.LocalDate;
import java.util.List;

@RestController
@RequestMapping("/api/v1/cats")
public class CatsController {
    private final CatsService service;

    @Autowired
    public CatsController(CatsService service) {
        this.service = service;
    }

    @PostMapping
    public CatReturnDto addCat(@RequestBody CatDto catDto) {
        return service.addCat(catDto);
    }

    @DeleteMapping("/{id}")
    public void deleteCat(@PathVariable("id") long id) {
        service.deleteCat(id);
    }

    @PostMapping("/cat/{catId}/owner/{ownerId}")
    public void setCatOwner(@PathVariable("catId") long catId, @PathVariable("ownerId") long ownerId) {
        service.setCatOwner(catId, ownerId);
    }

    @PostMapping("/cat/{id}/catFriend/{friendId}")
    public void addCatFriend(@PathVariable("id") long id, @PathVariable("friendId") long friendId) {
        service.addCatFriend(id, friendId);
    }

    @GetMapping
    public List<CatReturnDto> findByParams(@RequestParam(value = "color", required = false) Colors color, @RequestParam(value = "breed", required = false) Breeds breed) {
        if (color == null && breed == null) {
            return service.getAllCats();
        }

        if (color == null) {
            return service.findByBreed(breed);
        }
        else if (breed == null) {
            return service.findByColor(color);
        }

        return service.findByParams(color, breed);
    }
}
