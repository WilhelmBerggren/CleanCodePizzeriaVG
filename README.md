# CleanCodePizzeria
Members: Wilhelm Berggren, Nils Lundell

# Patterns used
## Singleton
We used a Singleton Pizzeria to ensure there can only be one instance of the pizzeria at a time.

## Visitor
We used a PizzeriaVisitor whose job is to extract a text representation of each model, to be presentable to the user. This avoids scattering ToString logic all over our models.

## Strategy
We used the strategy pattern inside the PizzeriaVisitor to be able to use a single generic method to handle all types of models. This simplifies its use across the codebase.