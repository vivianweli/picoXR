# picoVR
**Video Link**: https://youtu.be/jmiC_r5zTPU
**Group Members**: Vivian LI, Xintian FU\
We have three exhibits in our science fair: chemistry, biology, physics.
Unity version: 2020.3.34f1
## General
- We implemented virtual navigation by touch pad using gliding/flying metaphor
- We implemented hand manipulation with ray casting at a close offfset
## Chemistry: a volcanic eruption
<img width="313" alt="image" src="https://github.com/user-attachments/assets/c8e83c86-b393-4b5d-a0f3-029b000ee258">

- We demonstrate a reactive reaction between baking soda and vinegar in the form of a volcanic eruption.
- We used 3D TextMeshPro to display the title, instruction, and label on the table.
- Users click on the cup containing vinegar to trigger the pouring (particles flowing out simulation) and movement effect (cup is raised, tilted forward and back, and returned to the table). The level of vinegar is also visually decreased after pouring.
- When the vinegar particles collide with the volcano, another particle system simulating volcanic eruption activates and plays. The baking soda (white powder) on the volcano disappears.
- A 3D audio of volcanic eruption plays thereafter. 
- When user clicks on the beige pillar to reset the exhibit, the audio and particle eruption deactivies and stops, vinegar level is reset, and baking soda reappears.

## Biology: plant growth
<img width="313" alt="image" src="https://github.com/user-attachments/assets/ea80f737-3392-4f67-b84d-d9219c2124f8">

- We demonstrate the process of plant growth using the need for light and water.
- We used 3D TextMeshPro to display the title, instruction, and label on the table.
- Users turn on the light by clicking on the lamp base, which uses a spotlight. The light will automatically turn off after 15 seconds.
- Users need to click the water bottle within those 15 seconds to water the plant, and an animation of watering will be displayed. If the user does not water the plant when the light is still on, the watering will not result in growth.
- Once both light and water conditions are met, a countdown of 3-2-1 (not captured in the video) will appear at the top, and when the countdown ends, the plant will sprout a stem.
- The plant growth consists of three stages, so users need to turn on the light and water three times each.
- Finally, users can click the beige pillar to reset the exhibit.

## Physics: buoyancy
<img width="313" alt="image" src="https://github.com/user-attachments/assets/9ff3faa1-76c2-496b-9303-4ad4ed962065">

- We demonstrate a buoyancy experiment using eggs and liquids of different densities.
- We used 3D TextMeshPro to display the title, instruction, and label on the table.
- Users can grab and drop the egg into each container containing a different liquid (water, salt water, sugar water).
- Users then observe the different buoyancy of the egg in each container.
- We increased the drag of the egg that is dropped in each liquid according to the liquid density (e.g. in denser liquid, the drag is higher).
- We simulated buoyancy force with the impact of mass (although mass is all the same here) according to the liquid density (e.g. in denser liquid, the buoyancy force is higher).
- When user clicks on the beige pillar to reset the exhibit, the eggs are repositioned back on the table, and their velocities reset.
